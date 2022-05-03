using MVVMGenericStructure.Commands;
using MVVMGenericStructure.Services;
using MVVMGenericStructure.ViewModels;
using System.Windows.Input;

namespace WPF.ViewModel.Components
{
    public class NavigationMenuViewModel : ViewModelBase
    {
        private bool _isMenuOpen;
        public bool isMenuOpen
        {
            get
            {
                return _isMenuOpen;
            }
            set
            {
                _isMenuOpen = value;
                OnPropertyChanged(nameof(isMenuOpen));
            }
        }

        public ICommand navigateHomeCommand { get; }
        public ICommand navigateProductCommand { get; }
        public ICommand navigateProviderCommand { get; }
        public ICommand navigateEmployeeCommand { get; }

        public NavigationMenuViewModel
            (
                INavigationService navigateHomeCommand,
                INavigationService navigateProductCommand,
                INavigationService navigateProviderCommand,
                INavigationService navigateEmployeeCommand
            )
        {
            isMenuOpen = true;
            this.navigateHomeCommand = new NavigateCommand(navigateHomeCommand);
            this.navigateProductCommand = new NavigateCommand(navigateProductCommand);
            this.navigateProviderCommand = new NavigateCommand(navigateProviderCommand);
            this.navigateEmployeeCommand = new NavigateCommand(navigateEmployeeCommand);
        }
    }
}
