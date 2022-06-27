using MVVMGenericStructure.Commands;
using MVVMGenericStructure.Services;
using MVVMGenericStructure.ViewModels;
using System.Windows.Input;

namespace WPF.ViewModel.Components
{
    public class ConsultationModuleTabControlMenuViewModel : ViewModelBase
    {
        public ICommand navigatePatientConsultation{ get; }
        public ICommand navigateConsultationPage { get; }
        public ICommand navigatePatientPage { get; }

        public ConsultationModuleTabControlMenuViewModel
            (
                INavigationService navigatePatientConsultationService,
                INavigationService navigateConsultationPageService,
                INavigationService navigatePatientPageService
            )
        {
            navigatePatientConsultation = new NavigateCommand(navigatePatientConsultationService);
            navigateConsultationPage = new NavigateCommand(navigateConsultationPageService);
            navigatePatientPage = new NavigateCommand(navigatePatientPageService);
        }
    }
}
