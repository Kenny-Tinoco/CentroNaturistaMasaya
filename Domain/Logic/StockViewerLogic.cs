using Domain.DAO;
using Domain.Entities;
using Domain.Entities.Views;
using Domain.Services;
using Domain.Utilities;

namespace Domain.Logic
{
    public class StockViewerLogic
    {
        private readonly IViewsCollections viewsCollections;
        private readonly DAOFactory daoFactory;

        public StockViewerLogic(DAOFactory daoFactory, IViewsCollections viewsCollections)
        {
            this.viewsCollections = viewsCollections;
            this.daoFactory = daoFactory;
        }

        public async Task<IEnumerable<StockView>> GetStockListing() =>
            (await GetAllStockList())
            .Where(item => item.Quantity > 0);

        public async Task<IEnumerable<StockView>> GetAllStockList() =>
            await viewsCollections.StockViewCatalog(Views.OnlyActive);


        public async Task<IEnumerable<Presentation>> GetPresentationListing() =>
            await daoFactory.presentationDAO.GetActives();
    }
}
