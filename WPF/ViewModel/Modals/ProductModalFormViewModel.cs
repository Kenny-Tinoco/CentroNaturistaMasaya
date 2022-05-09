using Domain.Entities;
using MVVMGenericStructure.Services;
using System.Windows;
using System.Windows.Input;
using WPF.Command;
using WPF.Command.Navigation;
using WPF.Stores;
using WPF.ViewModel.Base;

namespace WPF.ViewModel
{
    public class ProductModalFormViewModel : ModalFormViewModel
    {
        public EntityStore _entityStore { get; set; }
        public ICommand SaveCommand { get; }

        public ProductModalFormViewModel(EntityStore parameter, INavigationService closeNavigationService) : base(closeNavigationService)
        {
            _entityStore = parameter;
            SaveCommand = new SaveEntityCommand(this, parameter);

            if (_entityStore.entity != null)
                entity = _entityStore.entity;
            else
                ResetEntity();
        }

        public override void ResetEntity()
        {
            entity = new Product();
            ((Product)entity).IdProduct = 0;
            name = "";
            description = "";
            ((Product)entity).Status = true;
        }

        public string titleBar => _entityStore.isEdition ? 
            "Editar Producto" : "Agregar Producto";

        public ICommand _deleteCommand;
        public ICommand DeleteCommand 
        { 
            get
            {
                if(_deleteCommand is null)
                    _deleteCommand = new RelayCommand(parameter => delete((Product)parameter));
                
                return _deleteCommand;
            }
        }
        public void delete(Product parameter)
        {
            var result = MessageBox
                .Show("¿Está seguro de eliminar este producto?\n" +
                      "Se desencadenará una eliminación en cascada de todos los registros que tengan alguna relación con este producto.\n\n" +
                      "Antes de eliminarlo considere la opción de deshabilitar este producto, dicha opción oculta todas las ocurrencias del " +
                      "mismo sin hacer eliminaciones.",
                      "Confirmar Eliminación", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
                new DeleteEntityCommand(this, _entityStore).Execute();
        }


        public string name
        {
            get
            {
                if (string.IsNullOrEmpty(((Product)entity).Name))
                    _errorsViewModel.AddError(nameof(name), "El nombre es nulo o vacio");

                return ((Product)entity).Name;
            }
            set
            {
                ((Product)entity).Name = value;
                _errorsViewModel.ClearErrors(nameof(name));

                if (string.IsNullOrEmpty(((Product)entity).Name))
                    _errorsViewModel.AddError(nameof(name), "Debe ingresar un nombre");

                OnPropertyChanged(nameof(name));
            }
        }

        public string description
        {
            get
            {
                if (string.IsNullOrEmpty(((Product)entity).Description))
                    _errorsViewModel.AddError(nameof(description), "El nombre es nulo o vacio");

                return ((Product)entity).Description;
            }
            set
            {
                ((Product)entity).Description = value;
                _errorsViewModel.ClearErrors(nameof(description));

                if (string.IsNullOrEmpty(((Product)entity).Description))
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
