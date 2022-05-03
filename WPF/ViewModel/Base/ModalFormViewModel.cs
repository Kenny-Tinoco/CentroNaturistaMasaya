using Domain.Entities;
using MVVMGenericStructure.Services;
using System;
using System.Collections;
using System.ComponentModel;

namespace WPF.ViewModel.Base
{
    public class ModalFormViewModel : ModalViewModel, INotifyDataErrorInfo
    {

        public ModalFormViewModel(INavigationService closeModalNavigationService) : base(closeModalNavigationService)
        {
            _errorsViewModel = new ErrorsViewModel();
            _errorsViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;
        }

        public virtual void ResetEntity() 
        {}

        public BaseEntity entity { get; set; }

        public virtual bool canCreate
        {
            get => !HasErrors;
            set { }
        }

        protected readonly ErrorsViewModel _errorsViewModel;

        public bool HasErrors => _errorsViewModel.HasErrors;

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsViewModel.GetErrors(propertyName);
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        private void ErrorsViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
            OnPropertyChanged(nameof(canCreate));
        }
    }
}
