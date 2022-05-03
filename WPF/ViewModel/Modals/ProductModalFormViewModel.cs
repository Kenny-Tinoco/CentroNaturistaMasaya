using Domain.Entities;
using MVVMGenericStructure.Services;
using System.Windows.Input;
using WPF.Command;
using WPF.Stores;
using WPF.ViewModel.Base;

namespace WPF.ViewModel
{
    public class ProductModalFormViewModel : ModalFormViewModel
    {
        public EntityStore _entityStore { get; }
        public ICommand EntityStoreCommand { get; }

        public ProductModalFormViewModel(EntityStore parameter, INavigationService closeNavigationService) : base(closeNavigationService)
        {
            _entityStore = parameter;
            EntityStoreCommand = new SaveEntityCommand(this, parameter);

            if (_entityStore.entity != null)
                entity = _entityStore.entity;
            else
                ResetEntity();
        }

        public override void ResetEntity()
        {
            entity = new Product()
            {
                idProduct = 0,
                name = "",
                description = ""
            };
            name = "";
            description = "";
        }

        public string titleBar
        {
            get
            {
                if (_entityStore.isEdition)
                    return "Editar Producto";

                return "Agregar Producto";
            }
        }

        public string name
        {
            get
            {
                if (string.IsNullOrEmpty(((Product)entity).name))
                    _errorsViewModel.AddError(nameof(name), "El nombre es nulo o vacio");

                return ((Product)entity).name;
            }
            set
            {
                ((Product)entity).name = value;
                _errorsViewModel.ClearErrors(nameof(name));

                if (string.IsNullOrEmpty(((Product)entity).name))
                    _errorsViewModel.AddError(nameof(name), "Debe ingresar un nombre");

                OnPropertyChanged(nameof(name));
            }
        }

        public string description
        {
            get
            {
                if (string.IsNullOrEmpty(((Product)entity).description))
                    _errorsViewModel.AddError(nameof(description), "El nombre es nulo o vacio");

                return ((Product)entity).description;
            }
            set
            {
                ((Product)entity).description = value;
                _errorsViewModel.ClearErrors(nameof(description));

                if (string.IsNullOrEmpty(((Product)entity).description))
                    _errorsViewModel.AddError(nameof(description), "Debe ingresar una descripción");

                OnPropertyChanged(nameof(description));
            }
        }

        private string _submitErrorMessage;
        public string SubmitErrorMessage
        {
            get
            {
                return _submitErrorMessage;
            }
            set
            {
                _submitErrorMessage = value;
                OnPropertyChanged(nameof(SubmitErrorMessage));

                OnPropertyChanged(nameof(HasSubmitErrorMessage));
            }
        }

        public bool HasSubmitErrorMessage => !string.IsNullOrEmpty(SubmitErrorMessage);
    }
}
