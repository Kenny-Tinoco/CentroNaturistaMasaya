using System.Windows.Input;
using MVVMGenericStructure.ViewModels;
using MVVMGenericStructure.Services;
using MVVMGenericStructure.Commands;

namespace WPF.ViewModel.Components
{
    public class TabControlMenuViewModel : ViewModelBase
    {
        public ICommand navigateStockPage { get; }
        public ICommand navigateProductPage { get; }
        public ICommand navigatePresentationModal { get; }

        public TabControlMenuViewModel
            (
                INavigationService navigateStockService,
                INavigationService navigateProductService,
                INavigationService navigatePresentationSevice
            )
        { 
            navigateStockPage = new NavigateCommand(navigateStockService);
            navigateProductPage = new NavigateCommand(navigateProductService);
            navigatePresentationModal = new NavigateCommand(navigatePresentationSevice);
        }
    }
}
