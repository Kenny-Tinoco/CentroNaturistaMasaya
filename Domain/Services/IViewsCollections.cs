using Domain.Entities.Views;

namespace Domain.Services
{
    public interface IViewsCollections
    {
        /*Colleciones de vistas*/
        Task<IEnumerable<SellView>> SellViewCatalog();
        Task<IEnumerable<StockView>> StockViewCatalog();
        Task<IEnumerable<SupplyView>> SupplyViewCatalog();
        Task<IEnumerable<ConsultView>> ConsultationViewCatalog();
        Task<IEnumerable<SaleDetailView>> SaleDetailViewCatalog();
        Task<IEnumerable<SupplyDetailView>> SupplyDetailViewCatalog();
    }
}
