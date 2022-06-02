using MVVMGenericStructure.ViewModels;
using System;
using System.Collections;
using System.ComponentModel;

namespace WPF.ViewModel.Base
{
    public class FormViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private readonly MessageViewModel _statusMessage;

        public FormViewModel()
        {
            errorsViewModel = new ErrorsViewModel();
            errorsViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;

            _statusMessage = new MessageViewModel();
        }


        private bool _isEditable;
        public virtual bool isEditable
        {
            get => _isEditable;
            set
            {
                _isEditable = value;
                OnPropertyChanged(nameof(isEditable));
            }
        }

        public virtual bool canCreate => !HasErrors;

        public string statusMessage
        {
            get => _statusMessage.message;
            set
            {
                _statusMessage.message = value;
                OnPropertyChanged(nameof(statusMessage));
                OnPropertyChanged(nameof(hasStatusMessage));
            }
        }

        public bool hasStatusMessage => _statusMessage.hasMessage;

        public readonly ErrorsViewModel errorsViewModel;

        public bool HasErrors => errorsViewModel.HasErrors;

        public IEnumerable GetErrors(string propertyName) => errorsViewModel.GetErrors(propertyName);

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        private void ErrorsViewModel_ErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
            OnPropertyChanged(nameof(canCreate));
        }
    }
}
