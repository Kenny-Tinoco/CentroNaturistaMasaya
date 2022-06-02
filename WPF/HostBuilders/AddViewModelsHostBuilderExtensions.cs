using Domain.Logic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVMGenericStructure.Services;
using MVVMGenericStructure.Stores;
using System;
using WPF.Services;
using WPF.Stores;
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
                services.AddTransient<ProductSelectionModalViewModel>(s => CreateStockModalViewModel(s));
                services.AddTransient<StockFormViewModel>(s => CreateStockFormViewModel(s));
                services.AddSingleton<ProductSaleViewModel>(s => CreateSellProductViewModel(s));
                services.AddTransient<PresentationModalViewModel>(s => CreatePresentationModalViewModel(s));
                services.AddTransient<ProductModalFormViewModel>(s => CreateProductModalViewModel(s));
                services.AddTransient<ProviderModalFormViewModel>(s => CreateProviderModalViewModel(s));
                services.AddTransient<EmployeeModalFormViewModel>(s => CreateEmployeeModalViewModel(s));
                services.AddTransient<SalesChargeModalViewModel>(s => CreateSaleChargeModalViewModel(s));

                services.AddSingleton<ProductViewModel>(s => CreateProductViewModel(s));
                services.AddSingleton<ProviderViewModel>(s => CreateProviderViewModel(s));
                services.AddSingleton<EmployeeViewModel>(s => CreateEmployeeViewModel(s));
                services.AddSingleton<StockViewModel>(s => CreateStockViewModel(s));
                services.AddSingleton<SaleViewModel>(s => CreateSaleViewModel(s));
                services.AddSingleton<HomeViewModel>(s => CreateHomeViewModel(s));
                services.AddSingleton<LoginViewModel>(s => CreateLoginViewModel(s));

                services.AddSingleton<INavigationService>(s => CreateLoginNavigationService(s));

                services.AddTransient<TabControlMenuViewModel>(s => CreateTabControlMenuViewModel(s));
                services.AddSingleton<ProductWindowsViewModel>(s => CreateProductWindowsViewModel(s));
                services.AddSingleton<NavigationMenuViewModel>(s => CreateNavigationMenuViewModel(s));

                services.AddSingleton<StartupViewModel>(s => CreateStartupViewModel(s));
            }
            );

            return host;
        }
        private static LoginViewModel CreateLoginViewModel(IServiceProvider servicesProvider)
        {
            return new LoginViewModel
            (
                servicesProvider.GetRequiredService<IAuthenticator>(),
                CreateHomeNavigationService(servicesProvider),
                servicesProvider.GetRequiredService<CloseModalNavigationService>()
            );
        }
        private static HomeViewModel CreateHomeViewModel(IServiceProvider serviceProvider)
        {
            return new HomeViewModel
            (
                CreateStockFormNavigationService(serviceProvider),
                CreateSellProductNavigationService(serviceProvider)
            );
        }
        private static StockViewModel CreateStockViewModel(IServiceProvider serviceProvider)
        {
            return StockViewModel.LoadViewModel
            (
                serviceProvider.GetRequiredService<LogicFactory>().stockLogic,
                serviceProvider.GetRequiredService<IMessenger>(),
                CreateStockFormNavigationService(serviceProvider)
            );
        }
        private static SaleViewModel CreateSaleViewModel(IServiceProvider serviceProvider)
        {
            return SaleViewModel.LoadViewModel
            (
                serviceProvider.GetRequiredService<LogicFactory>().saleLogic,
                serviceProvider.GetRequiredService<IMessenger>(),
                CreateSellProductNavigationService(serviceProvider)
            );
        }
        private static ProductViewModel CreateProductViewModel(IServiceProvider servicesProvider)
        {
            return ProductViewModel.LoadViewModel
            (
                servicesProvider.GetRequiredService<LogicFactory>().productLogic,
                servicesProvider.GetRequiredService<IMessenger>(),
                CreateProductModalNavigationService(servicesProvider)
            );
        }
        private static ProviderViewModel CreateProviderViewModel(IServiceProvider servicesProvider)
        {
            return ProviderViewModel.LoadViewModel
            (
                servicesProvider.GetRequiredService<LogicFactory>().providerLogic,
                servicesProvider.GetRequiredService<IMessenger>(),
                CreateProviderModalNavigationService(servicesProvider)
            );
        }
        private static EmployeeViewModel CreateEmployeeViewModel(IServiceProvider servicesProvider)
        {
            return EmployeeViewModel.LoadViewModel
            (
                servicesProvider.GetRequiredService<LogicFactory>().employeeLogic,
                servicesProvider.GetRequiredService<IMessenger>(),
                CreateEmployeeModalNavigationService(servicesProvider)
            );
        }
        private static StartupViewModel CreateStartupViewModel(IServiceProvider servicesProvider)
        {
            return new StartupViewModel
            (
                servicesProvider.GetRequiredService<NavigationStore>(),
                servicesProvider.GetRequiredService<ModalNavigationStore>(),
                servicesProvider.GetRequiredService<NavigationMenuViewModel>()
            );
        }
        private static StockFormViewModel CreateStockFormViewModel(IServiceProvider servicesProvider)
        {
            return new StockFormViewModel
            (
                servicesProvider.GetRequiredService<LogicFactory>().stockLogic,
                servicesProvider.GetRequiredService<IMessenger>(),
                CreateStockNavigationService(servicesProvider),
                CreateStockModalNavigationService(servicesProvider)
            );
        }
        private static ProductSaleViewModel CreateSellProductViewModel(IServiceProvider servicesProvider)
        {
            return new ProductSaleViewModel
            (
                servicesProvider.GetRequiredService<LogicFactory>().saleLogic,
                servicesProvider.GetRequiredService<IMessenger>(),
                CreateSaleNavigationService(servicesProvider),
                CreateSalesChargeModalNavigationService(servicesProvider),
                servicesProvider.GetRequiredService<IAccountStore>()
            );
        }
        private static ProductWindowsViewModel CreateProductWindowsViewModel(IServiceProvider servicesProvider)
        {
            return new ProductWindowsViewModel
            (
                servicesProvider.GetRequiredService<TabControlMenuViewModel>(),
                servicesProvider.GetRequiredService<StockViewModel>()
            );
        }
        private static ProductSelectionModalViewModel CreateStockModalViewModel(IServiceProvider servicesProvider)
        {
            return new ProductSelectionModalViewModel
            (
                servicesProvider.GetRequiredService<IMessenger>(),
                servicesProvider.GetRequiredService<CloseModalNavigationService>()
            );
        }
        private static ProviderModalFormViewModel CreateProviderModalViewModel(IServiceProvider servicesProvider)
        {
            return new ProviderModalFormViewModel
            (
                servicesProvider.GetRequiredService<IMessenger>(),
                servicesProvider.GetRequiredService<LogicFactory>().providerPhoneLogic,
                servicesProvider.GetRequiredService<CloseModalNavigationService>()
            );
        }
        private static EmployeeModalFormViewModel CreateEmployeeModalViewModel(IServiceProvider servicesProvider)
        {
            return new EmployeeModalFormViewModel
            (
                servicesProvider.GetRequiredService<IMessenger>(),
                servicesProvider.GetRequiredService<CloseModalNavigationService>()
            );
        }
        private static SalesChargeModalViewModel CreateSaleChargeModalViewModel(IServiceProvider servicesProvider)
        {
            return new SalesChargeModalViewModel
            (
                servicesProvider.GetRequiredService<IMessenger>(),
                servicesProvider.GetRequiredService<CloseModalNavigationService>()
            );
        }
        private static PresentationModalViewModel CreatePresentationModalViewModel(IServiceProvider servicesProvider)
        {
            return PresentationModalViewModel.LoadViewModel
            (
                servicesProvider.GetRequiredService<LogicFactory>().presentationModalLogic,
                servicesProvider.GetRequiredService<IMessenger>(),
                servicesProvider.GetRequiredService<CloseModalNavigationService>()
            );
        }
        private static ProductModalFormViewModel CreateProductModalViewModel(IServiceProvider servicesProvider)
        {
            return new ProductModalFormViewModel
            (
                servicesProvider.GetRequiredService<IMessenger>(),
                servicesProvider.GetRequiredService<CloseModalNavigationService>()
            );
        }
        private static NavigationMenuViewModel CreateNavigationMenuViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationMenuViewModel
            (
                CreateLoginNavigationService(serviceProvider),
                CreateHomeNavigationService(serviceProvider),
                CreateProductWindowsNavigationService(serviceProvider),
                CreateSaleNavigationService(serviceProvider),
                CreateProviderNavigationService(serviceProvider),
                CreateEmployeeNavigationService(serviceProvider)
            );
        }
        private static TabControlMenuViewModel CreateTabControlMenuViewModel(IServiceProvider serviceProvider)
        {
            return new TabControlMenuViewModel
            (
                CreateStockNavigationService(serviceProvider),
                CreateProductNavigationService(serviceProvider),
                CreatePresentationModalNavigationService(serviceProvider)
            );
        }

        private static INavigationService CreateLoginNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<LoginViewModel>
            (
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<LoginViewModel>()
            );
        }
        private static INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<HomeViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<HomeViewModel>()
            );
        }
        private static INavigationService CreateProductWindowsNavigationService(IServiceProvider serviceProvider)
        {

            return new NavigationService<ProductWindowsViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<ProductWindowsViewModel>()
            );
        }
        private static INavigationService CreateProviderNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<ProviderViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<ProviderViewModel>()
            );
        }
        private static INavigationService CreateEmployeeNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<EmployeeViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<EmployeeViewModel>()
            );
        }
        private static INavigationService CreateStockNavigationService(IServiceProvider serviceProvider)
        {
            return new TabControlNavigationService<StockViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<StockViewModel>(),
                () => serviceProvider.GetRequiredService<TabControlMenuViewModel>()
            );
        }
        private static INavigationService CreateSaleNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<SaleViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<SaleViewModel>()
            );
        }
        private static INavigationService CreateProductNavigationService(IServiceProvider serviceProvider)
        {
            return new TabControlNavigationService<ProductViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<ProductViewModel>(),
                () => serviceProvider.GetRequiredService<TabControlMenuViewModel>()
            );
        }
        private static INavigationService CreateStockModalNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<ProductSelectionModalViewModel>
            (
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<ProductSelectionModalViewModel>()
            );
        }
        private static INavigationService CreateStockFormNavigationService(IServiceProvider serviceProvider)
        {
            return new TabControlNavigationService<StockFormViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<StockFormViewModel>(),
                () => serviceProvider.GetRequiredService<TabControlMenuViewModel>()
            );
        }
        private static INavigationService CreateSellProductNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<ProductSaleViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<ProductSaleViewModel>()
            );
        }
        private static INavigationService CreatePresentationModalNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<PresentationModalViewModel>
            (
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<PresentationModalViewModel>()
            );
        }
        private static INavigationService CreateProductModalNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<ProductModalFormViewModel>
            (
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<ProductModalFormViewModel>()
            );
        }
        private static INavigationService CreateProviderModalNavigationService(IServiceProvider servicesProvider)
        {
            return new NavigationService<ProviderModalFormViewModel>
            (
                servicesProvider.GetRequiredService<ModalNavigationStore>(),
                () => servicesProvider.GetRequiredService<ProviderModalFormViewModel>()
            );
        }
        private static INavigationService CreateEmployeeModalNavigationService(IServiceProvider servicesProvider)
        {
            return new NavigationService<EmployeeModalFormViewModel>
            (
                servicesProvider.GetRequiredService<ModalNavigationStore>(),
                () => servicesProvider.GetRequiredService<EmployeeModalFormViewModel>()
            );
        }
        private static INavigationService CreateSalesChargeModalNavigationService(IServiceProvider servicesProvider)
        {
            return new NavigationService<SalesChargeModalViewModel>
            (
                servicesProvider.GetRequiredService<ModalNavigationStore>(),
                () => servicesProvider.GetRequiredService<SalesChargeModalViewModel>()
            );
        }
    }
}
