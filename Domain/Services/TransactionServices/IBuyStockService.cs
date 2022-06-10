using Domain.Entities;

namespace Domain.Services.TransactionServices
{
    public interface IBuyStockService
    {
        Task BuyStock(int idProvider, IEnumerable<SupplyDetail> listingDetail, double disocunt);
    }
}
