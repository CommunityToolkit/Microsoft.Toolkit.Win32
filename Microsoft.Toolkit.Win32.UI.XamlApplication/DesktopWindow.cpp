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