using Domain.Entities;
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
    public record SaleChargeModalMessage(double total); 
    public record SaleMessage(bool canSave);


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
        sale
    }

    public enum Operation
    {
        create,
        update,
        delete
    }
}
