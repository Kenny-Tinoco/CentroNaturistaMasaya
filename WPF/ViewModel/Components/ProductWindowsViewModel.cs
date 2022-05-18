using MVVMGenericStructure.ViewModels;

namespace WPF.ViewModel.Components
{
    public class ProductWindowsViewModel : ViewModelBase
    {
        public TabControlMenuViewModel tabControlBarMenuViewModel { get; }
        public ViewModelBase contentViewModel { get; }

        public ProductWindowsViewModel (TabControlMenuViewModel _tabControlMenu, ViewModelBase _contentViewModel)
        {
            tabControlBarMenuViewModel = _tabControlMenu;
            contentViewModel = _contentViewModel;
        }

        public override void Dispose()
        {
            tabControlBarMenuViewModel.Dispose();
            contentViewModel.Dispose();
            base.Dispose();
        }
    }
}
