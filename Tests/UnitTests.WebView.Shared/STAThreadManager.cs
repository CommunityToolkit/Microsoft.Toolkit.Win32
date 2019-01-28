// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

// Based on https://github.com/saikrishnav/testfxSTAext/blob/master/LICENSE

#if NETCOREAPP
namespace Microsoft.TestFx.STAExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class STAThreadManager
    {
        private Thread staThread;

        private AutoResetEvent actionAvailableWaithHandle = new AutoResetEvent(false);
        private AutoResetEvent runCompletedAvailableWaithHandle = new AutoResetEvent(false);

        private Action functionToExecuteOnThread;

        private TaskCompletionSource<bool> taskCompletionSource;

        private object lockObject = new object();

        private bool disposing = false;

        public bool Execute(Action functionToExecuteOnThread)
        {
            lock (lockObject)
            {
                // Ensure thread initialized
                EnsureThreadInitialized();

                // Initialize Thread-specific vars
                this.taskCompletionSource = new TaskCompletionSource<bool>();
                this.functionToExecuteOnThread = functionToExecuteOnThread;

                // Send signal to sta thread to execute above function
                this.actionAvailableWaithHandle.Set();

                // Wait for result
                var task = this.taskCompletionSource.Task;
                try
                {
                    task.Wait();
                    return task.Result;
                }
                catch (AggregateException ex)
                {
                    if (ex.InnerException != null)
                    {
                        throw ex.InnerException;
                    }
                    else throw;
                }
            }
        }

        private void EnsureThreadInitialized()
        {
            if (this.staThread == null)
            {
                this.staThread = new Thread(ThreadLoop);
                this.staThread.IsBackground = true;
                this.staThread.SetApartmentState(ApartmentState.STA);
                this.staThread.Name = "testfxSTAExThread";
                this.staThread.Start();

                // MsTestV2 has no way of telling the extensions that test run is complete so that they can cleanup
                // So we need to rely on AppDomain unload event to clean up resources
                // Destructor is useless as it gets called after AppDomain.unload killed all our threads
                // If we let the unload, it will throw "AppDomainUnloadedException" if any threads are still alive at the time
                AppDomain.CurrentDomain.DomainUnload += CurrentDomain_DomainUnload;
            }
        }

        private void CurrentDomain_DomainUnload(object sender, EventArgs e)
        {
            AppDomain.CurrentDomain.DomainUnload -= CurrentDomain_DomainUnload;
            Dispose();
        }

        public void Dispose()
        {
            if (!this.disposing)
            {
                this.disposing = true;
                if (this.staThread != null && this.staThread.IsAlive)
                {
                    this.runCompletedAvailableWaithHandle.Set();
                    // TODO: Better way to cleanup - 100ms is really arbitrary
                    if (!this.staThread.Join(100))
                    {
                        this.staThread.Abort();
                        this.staThread.Join();
                    }
                    this.staThread = null;
                }
            }
        }

        private void ThreadLoop()
        {
            var waitForActions = true;
            while (waitForActions)
            {
                var waitResult = WaitHandle.WaitAny(new WaitHandle[2] { actionAvailableWaithHandle, runCompletedAvailableWaithHandle });
                if (waitResult == 0)
                {
                    if (this.functionToExecuteOnThread != null)
                    {
                        try
                        {
                            this.functionToExecuteOnThread.Invoke();
                            this.taskCompletionSource?.SetResult(true);
                        }
                        catch (Exception ex)
                        {
                            if (disposing)
                            {
                                if (ex is ThreadAbortException)
                                {
                                    Thread.ResetAbort();
                                }
                                // Disposing, just exit the thread cleanly
                                waitForActions = false;
                            }
                            else
                            {
                                this.taskCompletionSource?.SetException(ex);
                            }
                        }
                    }
                }
                else
                {
                    waitForActions = false;
                }
            }
        }
    }
}
#endif