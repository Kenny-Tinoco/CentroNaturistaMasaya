using Domain.Entities;
using MVVMGenericStructure.Services;
using System.Threading.Tasks;
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
        public productMessage message { get; private set; }


        public ProductModalFormViewModel(IMessenger messenger, INavigationService closeModal) : base(closeModal)
        {
            this.messenger = messenger;
            this.messenger.Subscribe<productMessage>(this, ProductMessageSent);
        }


        private void ProductMessageSent(object parameter)
        {
            message = (productMessage)parameter;

            if (message.entity is null)
                ResetEntity();
            else
                entity = message.entity;
        }

        public override void ResetEntity()
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

        public string titleBar => message.isEdition ? "Editar Producto" : "Agregar Producto";

        public ICommand _deleteCommand;
        public ICommand DeleteCommand
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
            
            messenger.Send(new productModalMessage((Product)entity, Operation.delete));
            ExitCommand.Execute(null);
        }


        public ICommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand is null)
                    _saveCommand = new RelayCommand(parameter => Save((bool)parameter));

                return _saveCommand;
            }
        }
        public async void Save(bool isEdition)
        {
            if (!isEdition)
            {
                messenger.Send(new productModalMessage((Product)entity, Operation.create));
                ResetEntity();

                notification = "Guardado con éxito";
                await Task.Delay(3000);
                notification = "";
            }
            else
            {
                messenger.Send(new productModalMessage((Product)entity, Operation.update));
                ExitCommand.Execute(null);
            }
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

        private string _notification;
        public string notification
        {
            get => _notification;
            set
            {
                _notification = value;
                OnPropertyChanged(nameof(notification));
            }
        }
    }
}
