using Domain.Logic;
using Domain.Services.TransactionServices;
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
                services.AddSingleton<BuyProductsViewModel>(s => CreateBuyProductsViewModel(s));
                services.AddTransient<PresentationModalViewModel>(s => CreatePresentationModalViewModel(s));
                services.AddTransient<ProductModalFormViewModel>(s => CreateProductModalViewModel(s));
                services.AddTransient<ProviderModalFormViewModel>(s => CreateProviderModalViewModel(s));
                services.AddTransient<EmployeeModalFormViewModel>(s => CreateEmployeeModalViewModel(s));
                services.AddTransient<PatientModalFormViewModel>(s => CreatePatientModalViewModel(s));
                services.AddTransient<SalesChargeModalViewModel>(s => CreateSaleChargeModalViewModel(s));
                services.AddTransient<StockViewerViewModel>(s => CreateStockViewerViewModel(s));
                services.AddTransient<StockKeepingViewModel>(s => CreateStockKeepingViewModel(s));

                services.AddSingleton<ProductViewModel>(s => CreateProductViewModel(s));
                services.AddSingleton<ProviderViewModel>(s => CreateProviderViewModel(s));
                services.AddSingleton<EmployeeViewModel>(s => CreateEmployeeViewModel(s));
                services.AddSingleton<StockViewModel>(s => CreateStockViewModel(s));
                services.AddSingleton<SaleViewModel>(s => CreateSaleViewModel(s));
                services.AddSingleton<PurchaseViewModel>(s => CreatePurchaseViewModel(s));
                services.AddSingleton<PatientViewModel>(s => CreatePatientViewModel(s));
                services.AddSingleton<ConsultationViewModel>(s => CreateConsultationViewModel(s));
                services.AddSingleton<PatientConsultationViewModel>(s => CreatePatientConsultationViewModel(s));
                services.AddSingleton<HomeViewModel>(s => CreateHomeViewModel(s));
                services.AddSingleton<LoginViewModel>(s => CreateLoginViewModel(s));

                services.AddSingleton(s => CreateLoginNavigationService(s));

                services.AddTransient(s => CreateProductModuleTabControlMenuViewModel(s));
                services.AddTransient(s => CreatePurchaseModuleTabControlMenuViewModel(s));
                services.AddTransient(s => CreateConsultationModuleTabControlMenuViewModel(s));
                services.AddSingleton(s => CreateProductModuleViewModel(s));
                services.AddSingleton(s => CreatePurchaseModuleViewModel(s));
                services.AddSingleton(s => CreateConsultationModuleViewModel(s));
                services.AddSingleton(s => CreateNavigationMenuViewModel(s));

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
                CreateSellProductNavigationService(serviceProvider),
                CreateBuyProductsNavigationService(serviceProvider)
            );
        }
        private static StockViewModel CreateStockViewModel(IServiceProvider serviceProvider)
        {
            return StockViewModel.LoadViewModel
            (
                serviceProvider.GetRequiredService<LogicFactory>().stockLogic,
                serviceProvider.GetRequiredService<IMessenger>(),
                CreateStockFormNavigationService(serviceProvider),
                CreateStockKeepingNavigationService(serviceProvider)
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
        private static StockKeepingViewModel CreateStockKeepingViewModel(IServiceProvider servicesProvider)
        {
            return new StockKeepingViewModel
            (
                servicesProvider.GetRequiredService<IMessenger>(),
                servicesProvider.GetRequiredService<LogicFactory>().stockKeepingLogic,
                servicesProvider.GetRequiredService<CloseModalNavigationService>()
            );
        }
        private static ProductSaleViewModel CreateSellProductViewModel(IServiceProvider servicesProvider)
        {
            return new ProductSaleViewModel
            (
                servicesProvider.GetRequiredService<LogicFactory>().saleLogic,
                servicesProvider.GetRequiredService<IMessenger>(),
                servicesProvider.GetRequiredService<IAccountStore>(),
                servicesProvider.GetRequiredService<ISellStockService>(),
                servicesProvider.GetRequiredService<StockViewerViewModel>(),
                CreateSaleNavigationService(servicesProvider),
                CreateSalesChargeModalNavigationService(servicesProvider)
            );
        }
        private static ProductModuleViewModel CreateProductModuleViewModel(IServiceProvider servicesProvider)
        {
            return new ProductModuleViewModel
            (
                servicesProvider.GetRequiredService<ProductModuleTabControlMenuViewModel>(),
                servicesProvider.GetRequiredService<StockViewModel>()
            );
        }
        private static PurchaseModuleViewModel CreatePurchaseModuleViewModel(IServiceProvider servicesProvider)
        {
            return new PurchaseModuleViewModel
            (
                servicesProvider.GetRequiredService<PurchaseModuleTabControlMenuViewModel>(),
                servicesProvider.GetRequiredService<BuyProductsViewModel>()
            );
        }
        private static ConsultationModuleViewModel CreateConsultationModuleViewModel(IServiceProvider servicesProvider)
        {
            return new ConsultationModuleViewModel
            (
                servicesProvider.GetRequiredService<ConsultationModuleTabControlMenuViewModel>(),
                servicesProvider.GetRequiredService<BuyProductsViewModel>()
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
        private static PatientModalFormViewModel CreatePatientModalViewModel(IServiceProvider servicesProvider)
        {
            return new PatientModalFormViewModel
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
                CreateProductModuleNavigationService(serviceProvider),
                CreateSaleNavigationService(serviceProvider),
                CreatePurchaseModuleNavigationService(serviceProvider),
                CreateEmployeeNavigationService(serviceProvider),
                CreateConsultationModuleNavigationService(serviceProvider)
            );
        }
        private static ProductModuleTabControlMenuViewModel CreateProductModuleTabControlMenuViewModel(IServiceProvider serviceProvider)
        {
            return new ProductModuleTabControlMenuViewModel
            (
                CreateStockNavigationService(serviceProvider),
                CreateProductNavigationService(serviceProvider),
                CreatePresentationModalNavigationService(serviceProvider)
            );
        }

        private static PurchaseModuleTabControlMenuViewModel CreatePurchaseModuleTabControlMenuViewModel(IServiceProvider serviceProvider)
        {
            return new PurchaseModuleTabControlMenuViewModel
            (
                CreateBuyProductsNavigationService(serviceProvider),
                CreatePurchaseNavigationService(serviceProvider),
                CreateProviderNavigationService(serviceProvider)
            );
        }

        private static ConsultationModuleTabControlMenuViewModel CreateConsultationModuleTabControlMenuViewModel(IServiceProvider serviceProvider)
        {
            return new ConsultationModuleTabControlMenuViewModel
            (
                CreateBuyProductsNavigationService(serviceProvider),
                CreatePurchaseNavigationService(serviceProvider),
                CreateProviderNavigationService(serviceProvider)
            );
        }
        private static StockViewerViewModel CreateStockViewerViewModel(IServiceProvider servicesProvider)
        {
            return new StockViewerViewModel
                (
                    servicesProvider.GetRequiredService<LogicFactory>().stockViewerLogic,
                    servicesProvider.GetRequiredService<IMessenger>()
                );
        }
        private static BuyProductsViewModel CreateBuyProductsViewModel(IServiceProvider servicesProvider)
        {
            return new BuyProductsViewModel
            (
                servicesProvider.GetRequiredService<LogicFactory>().purchaseLogic,
                servicesProvider.GetRequiredService<IMessenger>(),
                servicesProvider.GetRequiredService<IBuyStockService>(),
                servicesProvider.GetRequiredService<StockViewerViewModel>()
            );
        }
        private static PurchaseViewModel CreatePurchaseViewModel(IServiceProvider servicesProvider)
        {
            return PurchaseViewModel.LoadViewModel
            (
                servicesProvider.GetRequiredService<LogicFactory>().purchaseLogic,
                servicesProvider.GetRequiredService<IMessenger>()
            );
        }
        private static PatientViewModel CreatePatientViewModel(IServiceProvider servicesProvider)
        {
            return PatientViewModel.LoadViewModel
            (
                servicesProvider.GetRequiredService<LogicFactory>().purchaseLogic,
                servicesProvider.GetRequiredService<IMessenger>(),
                CreatePatientModalNavigationService(servicesProvider)
            );
        }
        private static ConsultationViewModel CreateConsultationViewModel(IServiceProvider servicesProvider)
        {
            return ConsultationViewModel.LoadViewModel
            (
                servicesProvider.GetRequiredService<LogicFactory>().purchaseLogic,
                servicesProvider.GetRequiredService<IMessenger>()
            );
        }
        private static PatientConsultationViewModel CreatePatientConsultationViewModel(IServiceProvider servicesProvider)
        {
            return new PatientConsultationViewModel
            (
                servicesProvider.GetRequiredService<LogicFactory>().purchaseLogic,
                servicesProvider.GetRequiredService<IMessenger>(),
                CreatePatientModalNavigationService(servicesProvider)
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
        private static INavigationService CreateProductModuleNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<ProductModuleViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<ProductModuleViewModel>()
            );
        }
        private static INavigationService CreatePurchaseModuleNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<PurchaseModuleViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<PurchaseModuleViewModel>()
            );
        }
        private static INavigationService CreateProviderNavigationService(IServiceProvider serviceProvider)
        {
            return new PurchaseModuleTabControlNavigationService<ProviderViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<ProviderViewModel>(),
                () => serviceProvider.GetRequiredService<PurchaseModuleTabControlMenuViewModel>()
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
        private static INavigationService CreateConsultationModuleNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<ConsultationModuleViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<ConsultationModuleViewModel>()
            );
        }
        private static INavigationService CreateStockNavigationService(IServiceProvider serviceProvider)
        {
            return new ProductModuleTabControlNavigationService<StockViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<StockViewModel>(),
                () => serviceProvider.GetRequiredService<ProductModuleTabControlMenuViewModel>()
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
            return new ProductModuleTabControlNavigationService<ProductViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<ProductViewModel>(),
                () => serviceProvider.GetRequiredService<ProductModuleTabControlMenuViewModel>()
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
            return new ProductModuleTabControlNavigationService<StockFormViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<StockFormViewModel>(),
                () => serviceProvider.GetRequiredService<ProductModuleTabControlMenuViewModel>()
            );
        }
        private static INavigationService CreateStockKeepingNavigationService(IServiceProvider serviceProvider)
        {
            return new NavigationService<StockKeepingViewModel>
            (
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                () => serviceProvider.GetRequiredService<StockKeepingViewModel>()
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
        private static INavigationService CreateBuyProductsNavigationService(IServiceProvider serviceProvider)
        {
            return new PurchaseModuleTabControlNavigationService<BuyProductsViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<BuyProductsViewModel>(),
                () => serviceProvider.GetRequiredService<PurchaseModuleTabControlMenuViewModel>()
            );
        }
        private static INavigationService CreatePurchaseNavigationService(IServiceProvider serviceProvider)
        {
            return new PurchaseModuleTabControlNavigationService<PurchaseViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<PurchaseViewModel>(),
                () => serviceProvider.GetRequiredService<PurchaseModuleTabControlMenuViewModel>()
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
        private static INavigationService CreatePatientModalNavigationService(IServiceProvider servicesProvider)
        {
            return new NavigationService<PatientModalFormViewModel>
            (
                servicesProvider.GetRequiredService<ModalNavigationStore>(),
                () => servicesProvider.GetRequiredService<PatientModalFormViewModel>()
            );
        }
    }
}
