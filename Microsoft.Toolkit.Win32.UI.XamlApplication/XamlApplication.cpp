#include "pch.h"

#include "XamlApplication.h"

namespace winrt
{
    using namespace winrt::Windows::UI::Xaml;
    using namespace winrt::Windows::UI::Xaml::Hosting;
}

namespace winrt::Microsoft::Toolkit::Win32::UI::XamlHost::implementation
{
    XamlApplication::XamlApplication(const winrt::Windows::Foundation::Collections::IVector<winrt::Windows::UI::Xaml::Markup::IXamlMetadataProvider>& providers)
    {
        for (auto&& provider : providers)
        {
            m_providers.Append(provider);
        }

        Initialize();
    }

    void XamlApplication::Initialize()
    {
        auto outerWithRef = outer();
        outerWithRef->AddRef();
        winrt::Windows::UI::Xaml::Markup::IXamlMetadataProvider metdataProvider{ outerWithRef, winrt::take_ownership_from_abi };
        m_providers.Append(metdataProvider);

        const auto dispatcherQueue = winrt::Windows::System::DispatcherQueue::GetForCurrentThread();
        if (!dispatcherQueue)
        {
            m_windowsXamlManager = winrt::Hosting::WindowsXamlManager::InitializeForCurrentThread();
        }
    }

    winrt::Windows::Foundation::IClosable XamlApplication::WindowsXamlManager() const
    {
        return m_windowsXamlManager;
    }

    void XamlApplication::Close()
    {
        if (m_bIsClosed)
        {
            return;
        }

        m_bIsClosed = true;

        m_windowsXamlManager.Close();
        m_providers.Clear();
        m_windowsXamlManager = nullptr;

        Exit();
        {
            MSG msg = {};
            while (PeekMessageW(&msg, nullptr, 0, 0, PM_REMOVE))
            {
                ::DispatchMessageW(&msg);
            }
        }
    }

    XamlApplication::~XamlApplication()
    {
        Close();
    }

    winrt::Markup::IXamlType XamlApplication::GetXamlType(winrt::Interop::TypeName const& type)
    {
        for (const auto& provider : m_providers)
        {
            const auto xamlType = provider.GetXamlType(type);
            if (xamlType != nullptr)
            {
                return xamlType;
            }
        }

        return nullptr;
    }

    winrt::Markup::IXamlType XamlApplication::GetXamlType(winrt::hstring const& fullName)
    {
        for (const auto& provider : m_providers)
        {
            const auto xamlType = provider.GetXamlType(fullName);
            if (xamlType != nullptr)
            {
                return xamlType;
            }
        }

        return nullptr;
    }

    winrt::com_array<winrt::Markup::XmlnsDefinition> XamlApplication::GetXmlnsDefinitions()
    {
        std::list<winrt::Markup::XmlnsDefinition> definitions;
        for (const auto& provider : m_providers)
        {
            auto defs = provider.GetXmlnsDefinitions();
            for (const auto& def : defs)
            {
                definitions.insert(definitions.begin(), def);
            }
        }

        return winrt::com_array<winrt::Markup::XmlnsDefinition>(definitions.begin(), definitions.end());
    }

    winrt::Windows::Foundation::Collections::IVector<winrt::Markup::IXamlMetadataProvider> XamlApplication::MetadataProviders()
    {
        return m_providers;
    }
}

namespace winrt::Microsoft::Toolkit::Win32::UI::XamlHost::factory_implementation
{
    XamlApplication::XamlApplication()
    {
        // Workaround a bug where twinapi.appcore.dll and threadpoolwinrt.dll gets loaded after it has been unloaded
        // because of a call to GetActivationFactory
        const wchar_t* preloadDlls[] = {
            L"twinapi.appcore.dll",
            L"threadpoolwinrt.dll",
        };
        for (size_t i = 0; i < m_preloadInstances.size(); i++)
        {
            const auto module = ::LoadLibraryExW(preloadDlls[i], nullptr, 0);
            m_preloadInstances[i] = module;
        }
    }

    XamlApplication::~XamlApplication()
    {
        for (auto module : m_preloadInstances)
        {
            ::FreeLibrary(module);
        }
    }
}
