using MVVMGenericStructure.ViewModels;

namespace WPF.ViewModel.Components
{
    public class ConsultationModuleViewModel : ModuleViewModelBase
    {
        public ConsultationModuleViewModel(ConsultationModuleTabControlMenuViewModel _tabControlMenu, ViewModelBase _contentViewModel) : base
            (_tabControlMenu, _contentViewModel)
        {
        }
    }
}
