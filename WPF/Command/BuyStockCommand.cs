using Domain.Entities;
using Domain.Services.TransactionServices;
using MVVMGenericStructure.Commands;
using System;
using System.Threading.Tasks;
using WPF.ViewModel;
using WPF.ViewModel.Utilities;

namespace WPF.Command
{
    public class BuyStockCommand : AsyncCommandBase
    {
        private readonly BuyProductsViewModel _purchaseViewModel;
        private readonly IBuyStockService _buyStockService;

        public BuyStockCommand(BuyProductsViewModel purchaseViewModel, IBuyStockService buyStockService)
        {
            _purchaseViewModel = purchaseViewModel;
            _buyStockService = buyStockService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _purchaseViewModel.statusMessage = string.Empty;

            try
            {
                await _buyStockService
                    .BuyStock
                    (
                        _purchaseViewModel.providerSelected.idProvider, 
                        _purchaseViewModel.detailListing.ToEnumerable<SupplyDetail>(), 
                        _purchaseViewModel.discount
                    );

                _purchaseViewModel.Reset();
                _purchaseViewModel.statusMessage = "Compra existosa.";
            }
            catch (Exception)
            {
                _purchaseViewModel.statusMessage = "Falló la compra.\n Intente de nuevo";
            }
        }
    }
}
