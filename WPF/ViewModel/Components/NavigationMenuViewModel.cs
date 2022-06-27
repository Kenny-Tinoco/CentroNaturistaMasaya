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

        public ICommand navigateLoginCommand { get; }
        public ICommand navigateHomeCommand { get; }
        public ICommand navigateProductCommand { get; }
        public ICommand navigateSaleCommand { get; }
        public ICommand navigatePurchaseCommand { get; }
        public ICommand navigateEmployeeCommand { get; }
        public ICommand navigateConsultationCommand { get; }

        public NavigationMenuViewModel
            (
                INavigationService navigateLoginCommand, 
                INavigationService navigateHomeCommand,
                INavigationService navigateProductCommand,
                INavigationService navigateSaleCommand,
                INavigationService navigatePurchaseCommand,
                INavigationService navigateEmployeeCommand,
                INavigationService navigateConsultationCommand
            )
        {
            this.navigateLoginCommand = new NavigateCommand(navigateLoginCommand);
            this.navigateHomeCommand = new NavigateCommand(navigateHomeCommand);
            this.navigateProductCommand = new NavigateCommand(navigateProductCommand);
            this.navigateSaleCommand = new NavigateCommand(navigateSaleCommand);
            this.navigatePurchaseCommand = new NavigateCommand(navigatePurchaseCommand);
            this.navigateEmployeeCommand = new NavigateCommand(navigateEmployeeCommand);
            this.navigateConsultationCommand = new NavigateCommand(navigateConsultationCommand);
        }
    }
}
