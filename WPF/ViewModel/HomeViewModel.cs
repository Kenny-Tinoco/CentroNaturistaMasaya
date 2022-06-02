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

        public HomeViewModel
        (
            INavigationService logicNavigationService,
            INavigationService _navigateSaleProductCommand
        )
        {
            navigateLoginCommand = new NavigateCommand(logicNavigationService);
            navigateSaleProductCommand = new NavigateCommand(_navigateSaleProductCommand);
        }
    }
}
