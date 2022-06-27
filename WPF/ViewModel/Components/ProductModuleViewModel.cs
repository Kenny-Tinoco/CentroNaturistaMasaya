using MVVMGenericStructure.ViewModels;

namespace WPF.ViewModel.Components
{
    public class ProductModuleViewModel : ModuleViewModelBase
    {
        public ProductModuleViewModel (ProductModuleTabControlMenuViewModel _tabControlMenu, ViewModelBase _contentViewModel) : base(_tabControlMenu, _contentViewModel)
        {}
    }
}
