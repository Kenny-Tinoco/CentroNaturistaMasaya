using System.Windows.Input;
using MVVMGenericStructure.ViewModels;
using MVVMGenericStructure.Services;
using MVVMGenericStructure.Commands;

namespace WPF.ViewModel.Components
{
    public class ProductModuleTabControlMenuViewModel : ViewModelBase
    {
        public ICommand navigateStockPage { get; }
        public ICommand navigateProductPage { get; }
        public ICommand navigatePresentationModal { get; }

        public ProductModuleTabControlMenuViewModel
            (
                INavigationService navigateStockService,
                INavigationService navigateProductService,
                INavigationService navigatePresentationService
            )
        { 
            navigateStockPage = new NavigateCommand(navigateStockService);
            navigateProductPage = new NavigateCommand(navigateProductService);
            navigatePresentationModal = new NavigateCommand(navigatePresentationService);
        }
    }
}
