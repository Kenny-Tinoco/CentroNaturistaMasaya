using Domain.DAO;
using Domain.Entities;
using Domain.Entities.Views;
using Domain.Logic.Base;
using Domain.Services;

namespace Domain.Logic
{
    public class StockLogic : BaseLogic<Stock>
    {
        private readonly DAOFactory daoFactory;
        public IViewsCollections viewsCollections = null!;

        public StockLogic(DAOFactory parameter, IViewsCollections _viewsCollections) : this(parameter)
        {
            viewsCollections = _viewsCollections;
        }

        public StockLogic(DAOFactory parameter) : base(parameter.stockDAO)
        {
            daoFactory = parameter;
        }

        public static bool SearchLogic(StockView element, string parameter) => 
            element.IdStock.ToString().Contains(parameter) ||
            element.Name.ToLower().StartsWith(parameter.ToLower()) ||
            element.Presentation.ToLower().StartsWith(parameter.ToLower());

        public Stock GetStock(int id)
        {
            return ((StockDAO)_dao).GetStock(id);
        }

        public bool HasChangeableState(int id)
        {
            var element = GetStock(id);
            return element.ProductNavigation.Status
                   && element.PresentationNavigation.Status;
        }



        public async Task<IEnumerable<Product>> GetProductListing() => await daoFactory.productDAO.GetActives();

        public async Task<IEnumerable<Presentation>> GetPresentationListing() => await daoFactory.presentationDAO.GetActives();

    }
}
