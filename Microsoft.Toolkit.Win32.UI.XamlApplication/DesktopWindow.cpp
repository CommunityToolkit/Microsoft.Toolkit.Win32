#include "pch.h"

#include "DesktopWindow.h"

namespace xaml = ::winrt::Windows::UI::Xaml;

namespace winrt::Microsoft::Toolkit::Win32::UI::XamlHost::implementation
{
    #define XAML_HOSTING_WINDOW_CLASS_NAME L"XAML_HOSTING_WINDOW_CLASS"

    DesktopWindow::DesktopWindow()
    {
        Create();
    }

    void DesktopWindow::Show()
    {
        ::ShowWindow(_window.get(), SW_SHOW);
        ::UpdateWindow(_window.get());
        ::SetFocus(_window.get());

        MSG msg = {};
        while (GetMessage(&msg, nullptr, 0, 0))
        {
            TranslateMessage(&msg);
            DispatchMessage(&msg);
        }

        return; //(int)msg.wParam;
    }

    void DesktopWindow::Close()
    {
        if (m_bIsClosed)
        {
            return;
        }

        m_bIsClosed = true;

        _source.Close();
    }

    DesktopWindow::~DesktopWindow()
    {
        Close();
    }

    void DesktopWindow::Create()
    {
        if (!_window)
        {
            WNDCLASS wc{};
            wc.hCursor = LoadCursor(nullptr, IDC_ARROW);
            wc.hInstance = ::GetModuleHandle(nullptr);
            wc.lpszClassName = XAML_HOSTING_WINDOW_CLASS_NAME;
            wc.style = CS_HREDRAW | CS_VREDRAW;
            wc.lpfnWndProc = DesktopWindow::WndProc;
            wc.hIcon = NULL; // LoadIconW(wc.hInstance, MAKEINTRESOURCEW(IDI_APPICON));
            RegisterClass(&wc);
            WINRT_ASSERT(!_window);

            // Create the window with the default size here - During the creation of the
            // window, the system will give us a chance to set its size in WM_CREATE.
            // WM_CREATE will be handled synchronously, before CreateWindow returns.
            WINRT_VERIFY(CreateWindow(wc.lpszClassName,
                Title().c_str(),
                WS_OVERLAPPEDWINDOW,
                CW_USEDEFAULT,
                CW_USEDEFAULT,
                CW_USEDEFAULT,
                CW_USEDEFAULT,
                nullptr,
                nullptr,
                wc.hInstance,
                this));

            WINRT_ASSERT(_window);
        }
    }

    winrt::hstring DesktopWindow::Title()
    {
        return _title;
    }

    void DesktopWindow::Title(winrt::hstring title)
    {
        _title = title;
        ::SetWindowText(_window.get(), _title.c_str());
    }

    winrt::Windows::UI::Xaml::UIElement DesktopWindow::Content()
    {
        return _source.Content();
    }

    void DesktopWindow::Content(winrt::Windows::UI::Xaml::UIElement content)
    {
        _source.Content(content);
    }

    // Method Description:
    // - Called when the window has been resized (or maximized)
    // Arguments:
    // - width: the new width of the window _in pixels_
    // - height: the new height of the window _in pixels_
    void DesktopWindow::OnResize(const UINT width, const UINT height)
    {
        if (_interopWindowHandle)
        {
            // update the interop window size
            ::SetWindowPos(_interopWindowHandle, 0, 0, 0, width, height, SWP_SHOWWINDOW);
            const auto rootContent = _source.Content().as<winrt::Windows::UI::Xaml::FrameworkElement>();
            if (rootContent)
            {
                const auto size = GetLogicalSize();
                rootContent.Width(size.Width);
                rootContent.Height(size.Height);
            }
        }
    }

    // Method Description:
    // - Called when the window is minimized to the taskbar.
    void DesktopWindow::OnMinimize()
    {
        // TODO MSFT#21315817 Stop rendering island content when the app is minimized.
    }

    // Method Description:
    // - Called when the window is restored from having been minimized.
    void DesktopWindow::OnRestore()
    {
        // TODO MSFT#21315817 Stop rendering island content when the app is minimized.
    }

    [[nodiscard]] LRESULT __stdcall DesktopWindow::WndProc(HWND const window, UINT const message, WPARAM const wparam, LPARAM const lparam) noexcept
    {
        WINRT_ASSERT(window);

        if (WM_NCCREATE == message)
        {
            auto cs = reinterpret_cast<CREATESTRUCT*>(lparam);
            const auto that = static_cast<DesktopWindow*>(cs->lpCreateParams);
            WINRT_ASSERT(that);
            WINRT_ASSERT(!that->_window);
            that->_window = wil::unique_hwnd(window);
            SetWindowLongPtr(window, GWLP_USERDATA, reinterpret_cast<LONG_PTR>(that));

            EnableNonClientDpiScaling(window);
            that->_currentDpi = GetDpiForWindow(window);

            auto interop = that->_source.as<IDesktopWindowXamlSourceNative>();
            winrt::check_hresult(interop->AttachToWindow(window));
            winrt::check_hresult(interop->get_WindowHandle(&that->_interopWindowHandle));
        }
        else if (DesktopWindow * that = GetThisFromHandle(window))
        {
            return that->MessageHandler(message, wparam, lparam);
        }

        return DefWindowProc(window, message, wparam, lparam);
    }

    [[nodiscard]] LRESULT DesktopWindow::MessageHandler(UINT const message, WPARAM const wparam, LPARAM const lparam) noexcept
    {
        switch (message)
        {
        case WM_DPICHANGED:
        {
            return HandleDpiChange(_window.get(), wparam, lparam);
        }

        case WM_DESTROY:
        {
            PostQuitMessage(0);
            return 0;
        }

        case WM_SIZE:
        {
            UINT width = LOWORD(lparam);
            UINT height = HIWORD(lparam);

            switch (wparam)
            {
            case SIZE_MAXIMIZED:
                [[fallthrough]] ;
            case SIZE_RESTORED:
                if (_minimized)
                {
                    _minimized = false;
                    OnRestore();
                }

                // We always need to fire the resize event, even when we're transitioning from minimized.
                // We might be transitioning directly from minimized to maximized, and we'll need
                // to trigger any size-related content changes.
                OnResize(width, height);
                break;
            case SIZE_MINIMIZED:
                if (!_minimized)
                {
                    _minimized = true;
                    OnMinimize();
                }
                break;
            default:
                // do nothing.
                break;
            }
            break;
        }
        case CM_UPDATE_TITLE:
        {
            SetWindowTextW(_window.get(), _title.c_str());
            break;
        }
        }

        return DefWindowProc(_window.get(), message, wparam, lparam);
    }

    // DPI Change handler. on WM_DPICHANGE resize the window
    [[nodiscard]] LRESULT DesktopWindow::HandleDpiChange(const HWND hWnd, const WPARAM wParam, const LPARAM lParam)
    {
        _inDpiChange = true;
        const HWND hWndStatic = ::GetWindow(hWnd, GW_CHILD);
        if (hWndStatic != nullptr)
        {
            const UINT uDpi = HIWORD(wParam);

            // Resize the window
            auto lprcNewScale = reinterpret_cast<RECT*>(lParam);

            ::SetWindowPos(hWnd, nullptr, lprcNewScale->left, lprcNewScale->top, lprcNewScale->right - lprcNewScale->left, lprcNewScale->bottom - lprcNewScale->top, SWP_NOZORDER | SWP_NOACTIVATE);

            _currentDpi = uDpi;
        }
        _inDpiChange = false;
        return 0;
    }
}

namespace winrt::Microsoft::Toolkit::Win32::UI::XamlHost::factory_implementation
{
    DesktopWindow::DesktopWindow()
    {
    }

    DesktopWindow::~DesktopWindow()
    {
    }
}