using Domain.Entities;
using MVVMGenericStructure.Services;
using System.Windows;
using System.Windows.Input;
using WPF.Command.Navigation;
using WPF.Services;
using WPF.Stores;
using WPF.ViewModel.Base;

namespace WPF.ViewModel
{
    public class ProductModalFormViewModel : ModalFormViewModel
    {
        private readonly IMessenger messenger;


        public ProductModalFormViewModel(IMessenger _messenger, INavigationService closeModal) : base(closeModal)
        {
            messenger = _messenger;
            messenger.Subscribe<ProductMessage>(this, ProductMessageSent);
        }


        private void ProductMessageSent(object parameter)
        {
            isEditable = ((ProductMessage)parameter).isEdition;

            var element = ((ProductMessage)parameter).entity;

            if (element is null)
                ResetEntity();
            else
                entity = new Product()
                {
                    IdProduct = element.IdProduct,
                    Name = element.Name,
                    Description = element.Description,
                    Status = element.Status,
                    Quantity = element.Quantity
                };
        }

        private void ResetEntity()
        {
            entity = new Product()
            {
                IdProduct = 0,
                Name = "",
                Description = "",
                Status = true
            };

            OnPropertyChanged(nameof(name));
            OnPropertyChanged(nameof(description));
        }
        
        private Product GetEntity()
        {
            return new Product()
            {
                IdProduct = entity.IdProduct,
                Name = name.Trim(),
                Description = description.Trim(),
                Status = entity.Status,
                Quantity = entity.Quantity
            };
        }

        public Product entity
        {
            get => (Product)_entity;
            set
            {
                _entity = value;
                OnPropertyChanged(nameof(entity));
            }
        }

        public string titleBar => isEditable ? "Editar Producto" : "Agregar Producto";

        public ICommand _deleteCommand;
        public ICommand deleteCommand
        {
            get
            {
                if (_deleteCommand is null)
                    _deleteCommand = new RelayCommand(o => Delete());

                return _deleteCommand;
            }
        }
        public void Delete()
        {
            var result = MessageBox
                .Show("¿Está seguro de eliminar este producto?\n" +
                      "Se desencadenará una eliminación en cascada de todos los registros que tengan alguna relación con este producto.\n\n" +
                      "Antes de eliminarlo considere la opción de deshabilitar este producto, dicha opción oculta todas las ocurrencias del " +
                      "mismo sin hacer eliminaciones.",
                      "Confirmar Eliminación", MessageBoxButton.YesNo);

            if (result != MessageBoxResult.Yes)
                return;

            messenger.Send(new ProductModalMessage(entity, Operation.delete, this));
            exitCommand.Execute(null);
        }


        public ICommand _saveCommand;
        public ICommand saveCommand
        {
            get
            {
                if (_saveCommand is null)
                    _saveCommand = new RelayCommand(parameter => Save((bool)parameter));

                return _saveCommand;
            }
        }
        public void Save(bool isEdition)
        {
            if (!isEdition)
            {
                messenger.Send(new ProductModalMessage(GetEntity(), Operation.create, this));
                ResetEntity();
            }
            else
            {
                messenger.Send(new ProductModalMessage(GetEntity(), Operation.update, this));
                exitCommand.Execute(null);
            }
        }

        public string name
        {
            get
            {
                if (string.IsNullOrEmpty(entity.Name))
                    errorsViewModel.AddError(nameof(name), "El nombre es nulo o vacio");

                return entity.Name;
            }
            set
            {
                entity.Name = value;
                errorsViewModel.ClearErrors(nameof(name));

                if (string.IsNullOrEmpty(entity.Name.Trim()))
                    errorsViewModel.AddError(nameof(name), "Debe ingresar un nombre");

                OnPropertyChanged(nameof(name));
            }
        }
        
        public string description
        {
            get
            {
                if (string.IsNullOrEmpty(entity.Description.Trim()))
                    errorsViewModel.AddError(nameof(description), "El nombre es nulo o vacio");

                return entity.Description;
            }
            set
            {
                entity.Description = value;
                errorsViewModel.ClearErrors(nameof(description));

                if (string.IsNullOrEmpty(entity.Description.Trim()))
                    errorsViewModel.AddError(nameof(description), "Debe ingresar una descripción");

                OnPropertyChanged(nameof(description));
            }
        }
    }
}
