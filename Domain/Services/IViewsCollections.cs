using Domain.Entities.Views;
using Domain.Utilities;

namespace Domain.Services
{
    public interface IViewsCollections
    {
        /*Colleciones de vistas*/
        Task<IEnumerable<SaleView>> SaleViewCatalog(Periods period, int idEmployee);
        Task<IEnumerable<StockView>> StockViewCatalog(Views type);
        Task<IEnumerable<SupplyView>> SupplyViewCatalog(Periods period, int idProvider);
        Task<IEnumerable<ConsultView>> ConsultationViewCatalog(Views type);
        Task<IEnumerable<SaleDetailView>> SaleDetailViewCatalog();
        Task<IEnumerable<SupplyDetailView>> SupplyDetailViewCatalog();
    }
}
