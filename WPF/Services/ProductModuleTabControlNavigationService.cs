using WPF.ViewModel.Components;
using System;
using MVVMGenericStructure.ViewModels;
using MVVMGenericStructure.Services;
using MVVMGenericStructure.Stores;

namespace WPF.Services
{
    public class ProductModuleTabControlNavigationService<viewModelBase> : INavigationService where viewModelBase : ViewModelBase
    {
        private readonly INavigationStore _navigationStore;
        private readonly CreateViewModel<viewModelBase> _createViewModel;
        private readonly Func<ProductModuleTabControlMenuViewModel> _createNavigationMenuViewModel;

        public ProductModuleTabControlNavigationService
        (
            INavigationStore navigationStore,
            CreateViewModel<viewModelBase> createViewModel,
            Func<ProductModuleTabControlMenuViewModel> createNavigationMenuViewModel
        )
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
            _createNavigationMenuViewModel = createNavigationMenuViewModel;
        }

        public void Navigate()
        {
            _navigationStore.currentViewModel = new ProductModuleViewModel(_createNavigationMenuViewModel(), _createViewModel());
        }
    }
}
