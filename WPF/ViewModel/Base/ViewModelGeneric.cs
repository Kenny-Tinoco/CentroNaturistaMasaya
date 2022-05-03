using System;
using System.Collections;
using System.ComponentModel;
using Domain.Entities;
using Domain.Logic;
using WPF.ViewModel.Base;

namespace WPF.ViewModel
{
    public abstract class ViewModelGeneric<Entity> : ViewModelCatalogue<Entity>, INotifyDataErrorInfo where Entity : BaseEntity
    {
        public ViewModelGeneric(BaseLogic<Entity> _logic = null!) : base(_logic)
        {
            _errorsViewModel = new ErrorsViewModel();
            _errorsViewModel.ErrorsChanged += ErrorsViewModel_ErrorsChanged;
        }

        private bool _isEditable;
        public bool isEditable
        {
            get
            {
                return _isEditable;
            }
            set
            {
                _isEditable = value;
                OnPropertyChanged(nameof(isEditable));
            }
        }

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
