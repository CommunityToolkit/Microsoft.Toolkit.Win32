#pragma once

#include "DesktopWindow.g.h"
#include <winrt/Windows.UI.Xaml.Hosting.h>
#include <winrt/Windows.UI.ViewManagement.h>
#include <winrt/Windows.Foundation.Collections.h>
#include <wil/resource.h>

namespace winrt::Microsoft::Toolkit::Win32::UI::XamlHost::implementation
{
    // Custom window messages
    #define CM_UPDATE_TITLE (WM_USER + 1)

    class DesktopWindow : public DesktopWindowT<DesktopWindow>
    {
    public:
        DesktopWindow();
        virtual ~DesktopWindow();

        winrt::Windows::UI::Xaml::UIElement Content();
        void Content(winrt::Windows::UI::Xaml::UIElement content);

        winrt::hstring Title();
        void Title(winrt::hstring title);

        void Show();

        void Close();

        bool IsDisposed() const
        {
            return m_bIsClosed;
        }

        static DesktopWindow* GetThisFromHandle(HWND const window) noexcept
        {
            return reinterpret_cast<DesktopWindow*>(::GetWindowLongPtr(window, GWLP_USERDATA));
        }

    private:
        bool m_bIsClosed = false;

        void Create();

        [[nodiscard]] static LRESULT __stdcall WndProc(HWND const window, UINT const message, WPARAM const wparam, LPARAM const lparam) noexcept;

        [[nodiscard]] virtual LRESULT MessageHandler(UINT const message, WPARAM const wparam, LPARAM const lparam) noexcept;

        // DPI Change handler. on WM_DPICHANGE resize the window
        [[nodiscard]] LRESULT HandleDpiChange(const HWND hWnd, const WPARAM wParam, const LPARAM lParam);

        void OnCreate();
        void OnResize(const UINT width, const UINT height);
        void OnMinimize();
        void OnRestore();

        RECT GetWindowRect() const noexcept
        {
            RECT rc = { 0 };
            ::GetWindowRect(_window.get(), &rc);
            return rc;
        }

        HWND GetHandle() const noexcept
        {
            return _window.get();
        };

        float GetCurrentDpiScale() const noexcept
        {
            const auto dpi = ::GetDpiForWindow(_window.get());
            const auto scale = static_cast<float>(dpi) / static_cast<float>(USER_DEFAULT_SCREEN_DPI);
            return scale;
        }

        //// Gets the physical size of the client area of the HWND in _window
        SIZE GetPhysicalSize() const noexcept
        {
            RECT rect = {};
            GetClientRect(_window.get(), &rect);
            const auto windowsWidth = rect.right - rect.left;
            const auto windowsHeight = rect.bottom - rect.top;
            return SIZE{ windowsWidth, windowsHeight };
        }

        //// Gets the logical (in DIPs) size of a physical size specified by the parameter physicalSize
        //// Remarks:
        //// XAML coordinate system is always in Display Indepenent Pixels (a.k.a DIPs or Logical). However Win32 GDI (because of legacy reasons)
        //// in DPI mode "Per-Monitor and Per-Monitor (V2) DPI Awareness" is always in physical pixels.
        //// The formula to transform is:
        ////     logical = (physical / dpi) + 0.5 // 0.5 is to ensure that we pixel snap correctly at the edges, this is necessary with odd DPIs like 1.25, 1.5, 1, .75
        //// See also:
        ////   https://docs.microsoft.com/en-us/windows/desktop/LearnWin32/dpi-and-device-independent-pixels
        ////   https://docs.microsoft.com/en-us/windows/desktop/hidpi/high-dpi-desktop-application-development-on-windows#per-monitor-and-per-monitor-v2-dpi-awareness
        winrt::Windows::Foundation::Size GetLogicalSize(const SIZE physicalSize) const noexcept
        {
            const auto scale = GetCurrentDpiScale();
            // 0.5 is to ensure that we pixel snap correctly at the edges, this is necessary with odd DPIs like 1.25, 1.5, 1, .75
            const auto logicalWidth = (physicalSize.cx / scale) + 0.5f;
            const auto logicalHeigth = (physicalSize.cy / scale) + 0.5f;
            return winrt::Windows::Foundation::Size(logicalWidth, logicalHeigth);
        }

        winrt::Windows::Foundation::Size GetLogicalSize() const noexcept
        {
            return GetLogicalSize(GetPhysicalSize());
        }

        // Method Description:
        // - Sends a message to our message loop to update the title of the window.
        // Arguments:
        // - newTitle: a string to use as the new title of the window.
        // Return Value:
        // - <none>
        void UpdateTitle(std::wstring_view newTitle)
        {
            _title = newTitle;
            PostMessageW(_window.get(), CM_UPDATE_TITLE, 0, reinterpret_cast<LPARAM>(nullptr));
        };

    protected:
        wil::unique_hwnd _window;
        unsigned int _currentDpi = 0;
        bool _inDpiChange = false;
        winrt::hstring _title = L"";
        bool _minimized = false;
        HWND _interopWindowHandle;
        winrt::Windows::UI::Xaml::Hosting::DesktopWindowXamlSource _source{ nullptr };
    };
}

namespace winrt::Microsoft::Toolkit::Win32::UI::XamlHost::factory_implementation
{
    class DesktopWindow : public DesktopWindowT<DesktopWindow, implementation::DesktopWindow>
    {
    public:
        DesktopWindow();
        ~DesktopWindow();
    };
}
