using MVVMGenericStructure.Commands;
using MVVMGenericStructure.Services;
using MVVMGenericStructure.ViewModels;
using System.Windows.Input;

namespace WPF.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand navigateLoginCommand { get; }

        public HomeViewModel(INavigationService logicNavigationService)
        {
            navigateLoginCommand = new NavigateCommand(logicNavigationService);
        }
    }
}
