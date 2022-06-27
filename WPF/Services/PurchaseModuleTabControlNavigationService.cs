using MVVMGenericStructure.Services;
using MVVMGenericStructure.Stores;
using MVVMGenericStructure.ViewModels;
using System;
using WPF.ViewModel.Components;

namespace WPF.Services
{
    public class PurchaseModuleTabControlNavigationService<viewModelBase> : INavigationService where viewModelBase : ViewModelBase
    {
        private readonly INavigationStore _navigationStore;
        private readonly CreateViewModel<viewModelBase> _createViewModel;
        private readonly Func<PurchaseModuleTabControlMenuViewModel> _createNavigationMenuViewModel;

        public PurchaseModuleTabControlNavigationService
        (
            INavigationStore navigationStore,
            CreateViewModel<viewModelBase> createViewModel,
            Func<PurchaseModuleTabControlMenuViewModel> createNavigationMenuViewModel
        )
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _createNavigationMenuViewModel = createNavigationMenuViewModel;
        }

        public void Navigate()
        {
            _navigationStore.currentViewModel = new PurchaseModuleViewModel(_createNavigationMenuViewModel(), _createViewModel());
        }
    }
}
