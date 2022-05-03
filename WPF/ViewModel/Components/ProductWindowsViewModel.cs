using MVVMGenericStructure.ViewModels;

namespace WPF.ViewModel.Components
{
    public class ProductWindowsViewModel : ViewModelBase
    {
        public TabControlMenuViewModel tabControlBarMenuViewModel { get; }
        public ViewModelBase contentViewModel { get; }

        public ProductWindowsViewModel
            (
                TabControlMenuViewModel tabControlBarMenuViewModel,
                ViewModelBase contentViewModel
            )
        {
            this.tabControlBarMenuViewModel = tabControlBarMenuViewModel;
            this.contentViewModel = contentViewModel;
        }

        public override void Dispose()
        {
            tabControlBarMenuViewModel.Dispose();
            contentViewModel.Dispose();
            base.Dispose();
        }
    }
}
