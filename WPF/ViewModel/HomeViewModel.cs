using MVVMGenericStructure.Commands;
using MVVMGenericStructure.Services;
using MVVMGenericStructure.ViewModels;
using System.Windows.Input;

namespace WPF.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand navigateLoginCommand { get; }
        public ICommand navigateSaleProductCommand { get; }
        public ICommand navigateBuyProductCommand { get; }

        public HomeViewModel
        (
            INavigationService logicNavigationService,
            INavigationService _navigateSaleProductCommand,
            INavigationService _navigateBuyProductCommand
        )
        {
            navigateLoginCommand = new NavigateCommand(logicNavigationService);
            navigateBuyProductCommand = new NavigateCommand(_navigateBuyProductCommand);
            navigateSaleProductCommand = new NavigateCommand(_navigateSaleProductCommand);
        }
    }
}
