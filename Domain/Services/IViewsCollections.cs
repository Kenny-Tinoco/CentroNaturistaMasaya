using Domain.Entities.Views;
using Domain.Utilities;

namespace Domain.Services
{
    public interface IViewsCollections
    {
        /*Colleciones de vistas*/
        Task<IEnumerable<SellView>> SellViewCatalog(Views type);
        Task<IEnumerable<StockView>> StockViewCatalog(Views type);
        Task<IEnumerable<SupplyView>> SupplyViewCatalog(Views type);
        Task<IEnumerable<ConsultView>> ConsultationViewCatalog(Views type);
        Task<IEnumerable<SaleDetailView>> SaleDetailViewCatalog(Views type);
        Task<IEnumerable<SupplyDetailView>> SupplyDetailViewCatalog(Views type);
    }
}
