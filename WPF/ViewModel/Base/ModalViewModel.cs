using MVVMGenericStructure.Services;
using MVVMGenericStructure.ViewModels;
using System.Windows.Input;
using WPF.Command.Navigation;

namespace WPF.ViewModel.Base
{
    public class ModalViewModel : ViewModelBase
    {
        public ICommand exitCommand { get; protected set; }

        public ModalViewModel(INavigationService closeModalNavigationService)
        {
            exitCommand = new ExitModalCommand(closeModalNavigationService);
        }
    }
}
