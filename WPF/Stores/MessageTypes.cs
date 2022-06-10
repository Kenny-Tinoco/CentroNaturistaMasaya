using Domain.Entities;
using Domain.Entities.Views;
using System.Windows.Input;
using WPF.ViewModel.Base;

namespace WPF.Stores
{
    public record StockMessage(Stock entity, bool isEdition);
    public record ProductMessage(Product entity, bool isEdition);
    public record ProductModalMessage(Product entity, Operation operation, FormViewModel viewModel);
    public record ProviderMessage(Provider entity, bool isEdition);
    public record ProviderModalMessage(Provider entity, Operation operation, FormViewModel viewModel);
    public record EmployeeMessage(Employee entity, bool isEdition);
    public record EmployeeModalMessage(Employee entity, Operation operation, FormViewModel viewModel);
    public record SaleChargeModalMessage(double total, ICommand buyStockCommand); 
    public record SaleMessage(bool canSave);
    public record StockViewerMessage(StockView element, TransactionType transaction);
    public record StockKeepingMessage((int idStock, int quantity) message);


    public enum SaveSale
    {
        cancel,
        save
    }

    public enum Refresh
    {
        stock,
        product,
        presentation,
        sale,
        employee,
        purchase,
        provider
    }

    public enum TransactionType
    {
        sale,
        purchase,
        transactionNull
    }

    public enum Operation
    {
        create,
        update,
        delete
    }
}
