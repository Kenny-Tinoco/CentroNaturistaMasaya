using Domain.Entities;
using WPF.ViewModel.Base;

namespace WPF.Stores
{
    public record StockMessage(Stock entity, bool isEdition);
    public record ProductMessage(Product entity, bool isEdition);
    public record ProductModalMessage(Product entity, Operation operation, FormViewModel viewModel);
    public record ProviderMessage(Provider entity, bool isEdition);
    public record ProviderModalMessage(Provider entity, Operation operation);


    public enum Refresh
    {
        stock,
        product,
        presentation
    }

    public enum Operation
    {
        create,
        update,
        delete
    }
}
