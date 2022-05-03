using MVVMGenericStructure.Commands;
using MVVMGenericStructure.Services;

namespace WPF.Command.Navigation
{
    public class ExitModalCommand : CommandBase
    {
        private readonly INavigationService _navigationService;

        public ExitModalCommand( INavigationService navigationService )
        {
            _navigationService = navigationService;
        }

        public override void Execute( object parameter = null)
        {
            _navigationService.Navigate();
        }
    }
}
