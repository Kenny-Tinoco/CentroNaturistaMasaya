﻿using Domain.Entities;
using Domain.Logic;
using Domain.Logic.Base;
using Domain.Utilities;
using MVVMGenericStructure.Commands;
using MVVMGenericStructure.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using WPF.Command.CRUD;
using WPF.Command.Navigation;
using WPF.Services;
using WPF.Stores;
using WPF.ViewsComponent.Utilities;
using WPF.ViewModel.Base;

namespace WPF.ViewModel
{
    public class StockFormViewModel : FormViewModel
    {
        public string title => isEditable ? "Editar existencia" : "Agregar una nueva existencia";

        public ICommand backCommand { get; }
        public ICommand searchCommand { get; }

        private readonly StockLogic logic;

        public IMessenger messenger;


        public StockFormViewModel(ILogic _logic, IMessenger _messenger, INavigationService backNavigation, INavigationService modalNavigation)
        {
            backCommand = new NavigateCommand(backNavigation);
            searchCommand = new NavigateCommand(modalNavigation);

            logic = (StockLogic)_logic;

            messenger = _messenger;
            messenger.Subscribe<Refresh>(this, RefreshPresentation);
            messenger.Subscribe<Product>(this, ProductMessageSent);
            messenger.Subscribe<StockMessage>(this, StockMessageSent);
        }


        private async void RefreshPresentation(object parameter)
        {
            if ((Refresh)parameter is not Refresh.presentation)
                return;

            presentations = await logic.GetPresentationListing();
        }

        private void ProductMessageSent(object parameter)
        {
            currentProduct = (Product)parameter;
        }

        private void StockMessageSent(object parameter)
        {
            var message = (StockMessage)parameter;

            isEditable = message.isEdition;

            Load(message.entity);
        }

        public async void Load(Stock element)
        {
            presentations = await logic.GetPresentationListing();
            var catalogue = await logic.GetProductListing();

            messenger.Send(catalogue);

            InitializeProperties(element);
        }

        private void InitializeProperties(Stock parameter)
        {
            if (parameter is null)
                ResetValuesToProperties();
            else
                SetValuesToProperties(parameter);
        }

        private void ResetValuesToProperties()
        {
            price = 0;
            quantity = 1;
            entryDate = DateTime.Now;
            expiration = DateTime.Now.PlusOneYear();
            status = true;
            entity.Image = null;

            currentProduct = null;
            currentPresentation = presentations.Find(item => item.IdPresentation == 11);
        }

        private void SetValuesToProperties(Stock parameter)
        {
            entity = new Stock
            {
                IdStock = parameter.IdStock,
                IdProduct = parameter.IdProduct,
                IdPresentation = parameter.IdPresentation
            };

            price = parameter.Price;
            quantity = parameter.Quantity;
            status = parameter.Status;
            image = parameter.Image;
            InsertDates(parameter);

            currentProduct = parameter.ProductNavigation;
            currentPresentation = presentations.Find(item => item.IdPresentation == parameter.IdPresentation);
        }

        private void InsertDates(Stock parameter)
        {
            try
            {
                entryDate = (DateTime)parameter.EntryDate;
                expiration = (DateTime)parameter.Expiration;
            }
            catch
            {
                if (parameter.EntryDate == null && parameter.Expiration == null)
                {
                    entryDate = DateTime.Now;
                    expiration = DateTime.Now.PlusOneYear();
                }
                else if (parameter.EntryDate == null)
                {
                    entryDate = DateTime.Now;
                    expiration = (DateTime)parameter.Expiration;
                }
                else
                {
                    entryDate = (DateTime)parameter.EntryDate;
                    expiration = DateTime.Now.PlusOneYear();
                }
            }
        }


        public ICommand saveCommand => new RelayCommand(parameter => Save((bool)parameter));
        private void Save(bool isEdtion)
        {
            RunSaveCommand(isEditable);

            messenger.Send(Refresh.stock);
            ResetValuesToProperties();

            if (isEdtion)
                backCommand.Execute(-1);
        }


        public double price
        {
            get
            {
                if (entity.Price == 0)
                    errorsViewModel.AddError(nameof(price), "Ingrese un precio");

                return entity.Price;
            }
            set
            {
                entity.Price = value;
                errorsViewModel.ClearErrors(nameof(price));

                if (entity.Price == 0)
                    errorsViewModel.AddError(nameof(price), "Ingrese un precio");
                else if (entity.Price < 0)
                    errorsViewModel.AddError(nameof(price), "Ingrese un precio positivo");

                OnPropertyChanged(nameof(price));
            }
        }

        public int quantity
        {
            get
            {
                return entity.Quantity;
            }
            set
            {
                entity.Quantity = value;
                OnPropertyChanged(nameof(quantity));
            }
        }

        public DateTime? entryDate
        {
            get
            {
                return entity.EntryDate;
            }
            set
            {
                entity.EntryDate = value;

                errorsViewModel.ClearErrors(nameof(expiration));
                errorsViewModel.ClearErrors(nameof(entryDate));

                if (!hasEntryDateBeforeExpiration)
                {
                    errorsViewModel.AddError(nameof(entryDate), "La fecha de entrada no puede ser despues de la expiración");
                }
                else if (entity.EntryDate == entity.Expiration)
                    errorsViewModel.AddError(nameof(entryDate), "La fecha de entrada no puede ser igual a la expiración");

                OnPropertyChanged(nameof(entryDate));
            }
        }

        public DateTime? expiration
        {
            get
            {
                return entity.Expiration;
            }
            set
            {
                entity.Expiration = value;

                errorsViewModel.ClearErrors(nameof(expiration));
                errorsViewModel.ClearErrors(nameof(entryDate));

                if (!hasEntryDateBeforeExpiration)
                {
                    errorsViewModel.AddError(nameof(expiration), "La fecha de expiración no puede ser antes de la fecha de entrada.");
                }
                else if (entity.EntryDate == entity.Expiration)
                    errorsViewModel.AddError(nameof(expiration), "La fecha de expiración no puede ser igual a entrada");

                OnPropertyChanged(nameof(expiration));
            }
        }

        public bool status
        {
            get => entity.Status;
            private set
            {
                if (entity.Status != value)
                {
                    entity.Status = value;
                    OnPropertyChanged(nameof(status));
                }
            }
        }

        public byte[] image
        {
            get
            {
                if (entity.Image == null)
                    entity.Image = File.ReadAllBytes("Resource/Image/image-default.png");

                return entity.Image;
            }
            set
            {
                entity.Image = value;
                OnPropertyChanged(nameof(image));
            }
        }


        public ICommand changeStatusCommand => new RelayCommand(o => ChangeStatus());
        private void ChangeStatus()
        {
            bool flag = status;

            if (status)
            {
                var result = MessageBox
                    .Show("¿Está seguro de desactivar esta existencia?\nTodas las ocurrencias del mismo serán ocultadas en los catalogos donde aparezca", "Confirmar desactivación", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes) status = false;
            }
            else
                status = true;

            if (flag != status && isEditable)
            {
                RunSaveCommand(true);
                messenger.Send(Refresh.stock);
            }
        }


        private ICommand _selectImageCommand;
        public ICommand selectImageCommand
        {
            get
            {
                if (_selectImageCommand is null)
                    _selectImageCommand = new RelayCommand(o => GetImage());

                return _selectImageCommand;
            }
        }
        private void GetImage()
        {
            var imageSelected = Utilities.GetImage();

            if (imageSelected is not null)
                image = imageSelected;

            OnPropertyChanged(nameof(image));
        }


        private void RunSaveCommand(bool isEdition)
        {
            logic.entity = GetStock();
            new SaveCommand(logic, this).Execute(isEdition);
        }
        private Stock GetStock()
        {
            return new Stock()
            {
                IdStock = isEditable ? entity.IdStock : 0,
                IdProduct = currentProduct.IdProduct,
                IdPresentation = currentPresentation.IdPresentation,
                Price = price,
                Quantity = quantity,
                EntryDate = entryDate,
                Expiration = expiration,
                Status = status,
                Image = image
            };
        }


        public bool hasChangeableState => logic.HasChangeableState(entity.IdStock) && isEditable;
        public string changeableStateMessageError => !hasChangeableState ?
            "No se puede editar esta existencia debido a que el producto y/o la presentación no existen." +
            " \n\nVerifique que dichas entidades estén activadas." : "";


        private Stock _entity;
        private Stock entity
        {
            get
            {
                if (_entity == null)
                    _entity = new Stock();
                return _entity;
            }
            set => _entity = value;
        }

        private Product _currentProduct;
        public Product currentProduct
        {
            get
            {
                errorsViewModel.ClearErrors(nameof(productName));
                if (_currentProduct == null)
                    errorsViewModel.AddError(nameof(productName), "Elija un producto. Utilize la opción 'Búscar Producto'");

                return _currentProduct;
            }
            set
            {
                if (value != null)
                    errorsViewModel.ClearErrors(nameof(productName));

                _currentProduct = value;
                OnPropertyChanged(nameof(currentProduct));
                OnPropertyChanged(nameof(productName));
            }
        }
        public string productName => (_currentProduct is null) ? "" : _currentProduct.Name;

        private Presentation _currentPresentation;
        public Presentation currentPresentation
        {
            get
            {
                errorsViewModel.ClearErrors(nameof(currentPresentation));
                if (_currentPresentation == null)
                    errorsViewModel.AddError(nameof(currentPresentation), "Elija una presentación");

                return _currentPresentation;
            }
            set
            {
                _currentPresentation = value;
                OnPropertyChanged(nameof(currentPresentation));
            }
        }

        private IEnumerable<Presentation> _presentations;
        public IEnumerable<Presentation> presentations
        {
            get => _presentations;
            set
            {
                _presentations = value;
                OnPropertyChanged(nameof(presentations));
            }
        }


        public override bool canCreate => !HasErrors && hasEntryDateBeforeExpiration;
        private bool hasEntryDateBeforeExpiration => entity.EntryDate <= entity.Expiration;
    }
}
