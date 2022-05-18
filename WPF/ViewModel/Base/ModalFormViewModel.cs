using Domain.Entities;
using MVVMGenericStructure.Services;
using System.Windows.Input;

namespace WPF.ViewModel.Base
{
    public class ModalFormViewModel : FormViewModel
    {

        public ModalFormViewModel(INavigationService closeModal)
        {
            modal = new ModalViewModel(closeModal);
        }

        private ModalViewModel modal { get; }

        public ICommand exitCommand => modal.exitCommand;

        protected BaseEntity _entity { get; set; }
    }
}
