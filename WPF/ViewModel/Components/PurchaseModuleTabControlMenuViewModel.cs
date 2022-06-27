using MVVMGenericStructure.Commands;
using MVVMGenericStructure.Services;
using MVVMGenericStructure.ViewModels;
using System.Windows.Input;

namespace WPF.ViewModel.Components
{
    public class PurchaseModuleTabControlMenuViewModel : ViewModelBase
    {
        public ICommand navigateBuyProducts { get; }
        public ICommand navigatePurchasePage { get; }
        public ICommand navigateProvider { get; }

        public PurchaseModuleTabControlMenuViewModel
            (
                INavigationService navigateBuyProductService,
                INavigationService navigatePurchasePageService,
                INavigationService navigateProviderService
            )
        {
            navigateBuyProducts = new NavigateCommand(navigateBuyProductService);
            navigatePurchasePage = new NavigateCommand(navigatePurchasePageService);
            navigateProvider = new NavigateCommand(navigateProviderService);
        }
    }
}
