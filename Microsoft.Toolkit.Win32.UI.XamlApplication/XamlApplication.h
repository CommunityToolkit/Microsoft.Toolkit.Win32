#pragma once

#include "XamlApplication.g.h"
#include <winrt/Windows.UI.Xaml.Hosting.h>
#include <winrt/Windows.UI.ViewManagement.h>
#include <winrt/Windows.Foundation.Collections.h>
#include <Windows.h>

namespace winrt::Microsoft::Toolkit::Xaml::Markup::implementation
{
    class XamlApplication : public XamlApplicationT<XamlApplication, Windows::UI::Xaml::Markup::IXamlMetadataProvider>
    {
    public:
        XamlApplication();
        XamlApplication(winrt::Windows::UI::Xaml::Markup::IXamlMetadataProvider parentProvider);
        ~XamlApplication();

        void Init();
        void Close();

        winrt::Windows::Foundation::IClosable WindowsXamlManager() const;
        winrt::Microsoft::Toolkit::Xaml::Markup::ExecutionMode ExecutionMode() const
        {
            return m_executionMode;
        }

        winrt::Windows::UI::Xaml::Markup::IXamlType GetXamlType(winrt::Windows::UI::Xaml::Interop::TypeName const& type);
        winrt::Windows::UI::Xaml::Markup::IXamlType GetXamlType(winrt::hstring const& fullName);
        winrt::com_array<winrt::Windows::UI::Xaml::Markup::XmlnsDefinition> GetXmlnsDefinitions();

        winrt::Windows::Foundation::Collections::IVector<winrt::Windows::UI::Xaml::Markup::IXamlMetadataProvider> MetadataProviders();

    private:
        winrt::Microsoft::Toolkit::Xaml::Markup::ExecutionMode m_executionMode = ExecutionMode::Win32;
        winrt::Windows::UI::Xaml::Hosting::WindowsXamlManager m_windowsXamlManager = nullptr;
        winrt::Windows::Foundation::Collections::IVector<winrt::Windows::UI::Xaml::Markup::IXamlMetadataProvider> m_providers = winrt::single_threaded_vector<Windows::UI::Xaml::Markup::IXamlMetadataProvider>();
        bool m_bIsClosed = false;
    };
}

namespace winrt::Microsoft::Toolkit::Xaml::Markup::factory_implementation
{
    class XamlApplication : public XamlApplicationT<XamlApplication, implementation::XamlApplication>
    {
    public:
        XamlApplication();
        ~XamlApplication();
    private:
        std::vector<HMODULE> m_preloadInstances;
    };
}
