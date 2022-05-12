using Domain.Entities;

namespace WPF.Stores
{
    public record StockMessage(Stock entity, bool isEdition);
    public record productMessage(Product entity, bool isEdition);
    public record productModalMessage(Product entity, Operation operation);

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
