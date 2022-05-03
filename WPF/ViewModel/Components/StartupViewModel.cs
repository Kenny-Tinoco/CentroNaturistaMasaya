using MVVMGenericStructure.Stores;
using MVVMGenericStructure.ViewModels;
using System.Windows.Input;
using WPF.Command.Navigation;

namespace WPF.ViewModel.Components
{
    public class StartupViewModel : ViewModelBase
    {

        private readonly NavigationStore _navigationStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        public ViewModelBase currentViewModel => _navigationStore.currentViewModel;
        public ViewModelBase currentModalViewModel => _modalNavigationStore.currentViewModel;
        public bool isOpen => _modalNavigationStore.isOpen;

        public ICommand stateBarCommand { get; }
        public ViewModelBase contentViewModel { get; }
        public NavigationMenuViewModel navigationMenuViewModel { get; }


        public StartupViewModel(NavigationStore navigationStore, ModalNavigationStore modalNavigationStore, NavigationMenuViewModel navigationMenuViewModel)
        {
            _navigationStore = navigationStore;
            _modalNavigationStore = modalNavigationStore;

            _navigationStore.currentViewModelChanged += OnCurrentViewModelChanged;
            _modalNavigationStore.currentViewModelChanged += OnCurrentModalViewModelChanged;

            this.navigationMenuViewModel = navigationMenuViewModel;
            contentViewModel = navigationStore.currentViewModel;

            stateBarCommand = new StateBarCommand();
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(currentViewModel));
        }

        private void OnCurrentModalViewModelChanged()
        {
            OnPropertyChanged(nameof(currentModalViewModel));
            OnPropertyChanged(nameof(isOpen));
        }

        public override void Dispose()
        {
            navigationMenuViewModel.Dispose();
            contentViewModel.Dispose();
            base.Dispose();
        }
    }
}
