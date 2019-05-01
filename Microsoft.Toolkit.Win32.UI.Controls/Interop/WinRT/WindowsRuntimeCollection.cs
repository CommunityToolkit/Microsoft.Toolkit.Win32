// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT
{
    internal sealed class WindowsRuntimeCollection<T1, T2> : IList<T1>
    {
        private readonly IList<T2> collection;
        private readonly Func<T2, T1> converter1;
        private readonly Func<T1, T2> converter2;

        public WindowsRuntimeCollection(IList<T2> collection, Func<T2, T1> converter1, Func<T1, T2> converter2)
        {
            this.collection = collection;
            this.converter1 = converter1;
            this.converter2 = converter2;
        }

        T1 IList<T1>.this[int index]
        {
            get => this.converter1(this.collection[index]);
            set => this.collection[index] = this.converter2(value);
        }

        int ICollection<T1>.Count => this.collection.Count;

        bool ICollection<T1>.IsReadOnly => this.collection.IsReadOnly;

        void ICollection<T1>.Add(T1 item)
        {
            this.collection.Add(this.converter2(item));
        }

        void ICollection<T1>.Clear()
        {
            this.collection.Clear();
        }

        bool ICollection<T1>.Contains(T1 item)
        {
            return this.collection.Contains(this.converter2(item));
        }

        void ICollection<T1>.CopyTo(T1[] array, int arrayIndex)
        {
            this.collection.CopyTo(array.Select(e => this.converter2(e)).ToArray(), arrayIndex);
        }

        IEnumerator<T1> IEnumerable<T1>.GetEnumerator()
        {
            foreach (var e in this.collection)
            {
                yield return this.converter1(e);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var e in this.collection)
            {
                yield return this.converter1(e);
            }
        }

        int IList<T1>.IndexOf(T1 item)
        {
            return this.collection.IndexOf(this.converter2(item));
        }

        void IList<T1>.Insert(int index, T1 item)
        {
            this.collection.Insert(index, this.converter2(item));
        }

        bool ICollection<T1>.Remove(T1 item)
        {
            return this.collection.Remove(this.converter2(item));
        }

        void IList<T1>.RemoveAt(int index)
        {
            this.collection.RemoveAt(index);
        }
    }
}
