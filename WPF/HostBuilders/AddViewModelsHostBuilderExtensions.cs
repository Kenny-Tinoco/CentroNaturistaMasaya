using Domain.Logic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVMGenericStructure.Services;
using MVVMGenericStructure.Stores;
using System;
using WPF.Services;
using WPF.ViewModel;
using WPF.ViewModel.Components;

namespace WPF.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices
            (services =>
            {
                services.AddTransient<ProductSelectionModalViewModel>(s => createStockModalViewModel(s));
                services.AddTransient<StockFormViewModel>(s => createStockFormViewModel(s));
                services.AddTransient<PresentationModalViewModel>(s => createPresentationModalViewModel(s));
                services.AddTransient<ProductModalFormViewModel>(s => createProductModalViewModel(s));
                services.AddTransient<ProviderModalFormViewModel>(s => createProviderModalViewModel(s));
                services.AddTransient<EmployeeModalFormViewModel>(s => createEmployeeModalViewModel(s));

                services.AddSingleton<ProductViewModel>(s => createProductViewModel(s));
                services.AddSingleton<ProviderViewModel>(s => createProviderViewModel(s));
                services.AddSingleton<EmployeeViewModel>(s => createEmployeeViewModel(s));
                services.AddSingleton<StockViewModel>(s => createStockViewModel(s));
                services.AddSingleton<HomeViewModel>(s => createHomeViewModel(s));

                services.AddSingleton<INavigationService>(s => createHomeNavigationService(s));

                services.AddTransient<TabControlMenuViewModel>(s => createTabControlMenuViewModel(s));
                services.AddSingleton<ProductWindowsViewModel>(s => createProductWindowsViewModel(s));
                services.AddSingleton<NavigationMenuViewModel>(s => createNavigationMenuViewModel(s));

                services.AddSingleton<StartupViewModel>(s => createStartupViewModel(s));
            }
            );

            return host;
        }

        private static HomeViewModel createHomeViewModel(IServiceProvider serviceProvider)
        {
            return new HomeViewModel
            (
                createStockFormNavigationService(serviceProvider)
            );
        }
        private static StockViewModel createStockViewModel(IServiceProvider serviceProvider)
        {
            return StockViewModel.LoadViewModel
            (
                serviceProvider.GetRequiredService<LogicFactory>().stockLogic,
                serviceProvider.GetRequiredService<IMessenger>(),
                createStockFormNavigationService(serviceProvider)
            );
        }
        private static ProductViewModel createProductViewModel(IServiceProvider servicesProvider)
        {
            return ProductViewModel.LoadViewModel
            (
                servicesProvider.GetRequiredService<LogicFactory>().productLogic,
                servicesProvider.GetRequiredService<IMessenger>(),
                createProductModalNavigationService(servicesProvider)
            );
        }
        private static ProviderViewModel createProviderViewModel(IServiceProvider servicesProvider)
        {
            return ProviderViewModel.LoadViewModel
            (
                servicesProvider.GetRequiredService<LogicFactory>().providerLogic,
                servicesProvider.GetRequiredService<IMessenger>(),
                createProviderModalNavigationService(servicesProvider)
            );
        }
        private static EmployeeViewModel createEmployeeViewModel(IServiceProvider servicesProvider)
        {
            return EmployeeViewModel.LoadViewModel
            (
                servicesProvider.GetRequiredService<LogicFactory>().employeeLogic,
                servicesProvider.GetRequiredService<IMessenger>(),
                createEmployeeModalNavigationService(servicesProvider)
            );
        }
        private static StartupViewModel createStartupViewModel(IServiceProvider servicesProvider)
        {
            return new StartupViewModel
            (
                servicesProvider.GetRequiredService<NavigationStore>(),
                servicesProvider.GetRequiredService<ModalNavigationStore>(),
                servicesProvider.GetRequiredService<NavigationMenuViewModel>()
            );
        }
        private static StockFormViewModel createStockFormViewModel(IServiceProvider servicesProvider)
        {
            return new StockFormViewModel
            (
                servicesProvider.GetRequiredService<LogicFactory>(),
                servicesProvider.GetRequiredService<IMessenger>(),
                createStockNavigationService(servicesProvider),
                createStockModalNavigationService(servicesProvider)
            );
        }
        private static ProductWindowsViewModel createProductWindowsViewModel(IServiceProvider servicesProvider)
        {
            return new ProductWindowsViewModel
            (
                servicesProvider.GetRequiredService<TabControlMenuViewModel>(),
                servicesProvider.GetRequiredService<StockViewModel>()
            );
        }
        private static ProductSelectionModalViewModel createStockModalViewModel(IServiceProvider servicesProvider)
        {
            return new ProductSelectionModalViewModel
            (
                servicesProvider.GetRequiredService<IMessenger>(),
                servicesProvider.GetRequiredService<CloseModalNavigationService>()
            );
        }
        private static ProviderModalFormViewModel createProviderModalViewModel(IServiceProvider servicesProvider)
        {
            return new ProviderModalFormViewModel
            (
                servicesProvider.GetRequiredService<IMessenger>(),
                servicesProvider.GetRequiredService<LogicFactory>().providerPhoneLogic,
                servicesProvider.GetRequiredService<CloseModalNavigationService>()
            );
        }
        private static EmployeeModalFormViewModel createEmployeeModalViewModel(IServiceProvider servicesProvider)
        {
            return new EmployeeModalFormViewModel
            (
                servicesProvider.GetRequiredService<IMessenger>(),
                servicesProvider.GetRequiredService<CloseModalNavigationService>()
            );
        }
        private static PresentationModalViewModel createPresentationModalViewModel(IServiceProvider servicesProvider)
        {
            return PresentationModalViewModel.LoadViewModel
            (
                servicesProvider.GetRequiredService<LogicFactory>().presentationModalLogic,
                servicesProvider.GetRequiredService<IMessenger>(),
                servicesProvider.GetRequiredService<CloseModalNavigationService>()
            );
        }
        private static ProductModalFormViewModel createProductModalViewModel(IServiceProvider servicesProvider)
        {
            return new ProductModalFormViewModel
            (
                servicesProvider.GetRequiredService<IMessenger>(),
                servicesProvider.GetRequiredService<CloseModalNavigationService>()
            );
        }
        private static NavigationMenuViewModel createNavigationMenuViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationMenuViewModel
            (
                createHomeNavigationService(serviceProvider),
                createProductWindowsNavigationService(serviceProvider),
                createProviderNavigationService(serviceProvider),
                createEmployeeNavigationService(serviceProvider)
            );
        }
        private static TabControlMenuViewModel createTabControlMenuViewModel(IServiceProvider serviceProvider)
        {
            return new TabControlMenuViewModel
            (
                createStockNavigationService(serviceProvider),
                createProductNavigationService(serviceProvider),
                createPresentationModalNavigationService(serviceProvider)
            );
        }


        private static INavigationService createHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<HomeViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<HomeViewModel>()
            );
        }
        private static INavigationService createProductWindowsNavigationService(IServiceProvider serviceProvider)
        {

            return new NavigationService<ProductWindowsViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<ProductWindowsViewModel>()
            );
        }
        private static INavigationService createProviderNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<ProviderViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<ProviderViewModel>()
            );
        }
        private static INavigationService createEmployeeNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<EmployeeViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<EmployeeViewModel>()
            );
        }
        private static INavigationService createStockNavigationService(IServiceProvider serviceProvider)
        {
            return new TabControlNavigationService<StockViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<StockViewModel>(),
                () => serviceProvider.GetRequiredService<TabControlMenuViewModel>()
            );
        }
        private static INavigationService createProductNavigationService(IServiceProvider serviceProvider)
        {
            return new TabControlNavigationService<ProductViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<ProductViewModel>(),
                () => serviceProvider.GetRequiredService<TabControlMenuViewModel>()
            );
        }
        private static INavigationService createStockModalNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<ProductSelectionModalViewModel>
            (
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<ProductSelectionModalViewModel>()
            );
        }
        private static INavigationService createStockFormNavigationService(IServiceProvider serviceProvider)
        {
            return new TabControlNavigationService<StockFormViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<StockFormViewModel>(),
                () => serviceProvider.GetRequiredService<TabControlMenuViewModel>()
            );
        }
        private static INavigationService createPresentationModalNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<PresentationModalViewModel>
            (
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<PresentationModalViewModel>()
            );
        }
        private static INavigationService createProductModalNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<ProductModalFormViewModel>
            (
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<ProductModalFormViewModel>()
            );
        }
        private static INavigationService createProviderModalNavigationService(IServiceProvider servicesProvider)
        {
            return new NavigationService<ProviderModalFormViewModel>
            (
                servicesProvider.GetRequiredService<ModalNavigationStore>(),
                () => servicesProvider.GetRequiredService<ProviderModalFormViewModel>()
            );
        }
        private static INavigationService createEmployeeModalNavigationService(IServiceProvider servicesProvider)
        {
            return new NavigationService<EmployeeModalFormViewModel>
            (
                servicesProvider.GetRequiredService<ModalNavigationStore>(),
                () => servicesProvider.GetRequiredService<EmployeeModalFormViewModel>()
            );
        }
    }
}
