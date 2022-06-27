using MVVMGenericStructure.ViewModels;

namespace WPF.ViewModel.Components
{
    public class ModuleViewModelBase : ViewModelBase
    {
        public ModuleViewModelBase(ViewModelBase tabControlViewModel, ViewModelBase contentViewModel)
        {
            this.tabControlViewModel = tabControlViewModel;
            this.contentViewModel = contentViewModel;
        }

        public ViewModelBase tabControlViewModel { get; }
        public ViewModelBase contentViewModel { get; }


        public override void Dispose()
        {
            tabControlViewModel.Dispose();
            contentViewModel.Dispose();
            base.Dispose();
        }
    }
}
