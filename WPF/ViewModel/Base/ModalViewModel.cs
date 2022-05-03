using MVVMGenericStructure.Services;
using MVVMGenericStructure.ViewModels;
using System.Windows.Input;
using WPF.Command.Navigation;

namespace WPF.ViewModel.Base
{
    public class ModalViewModel : ViewModelBase
    {
        public ICommand ExitCommand { get; }

        public ModalViewModel(INavigationService closeModalNavigationService)
        {
            ExitCommand = new ExitModalCommand(closeModalNavigationService);
        }
    }
}
