using Domain.DAO;
using Domain.Entities;
using Domain.Entities.Views;
using Domain.Services;

namespace Domain.Logic
{
    public class StockLogic : BaseLogic<Stock>
    {
        public IViewsCollections viewsCollections;
        public StockLogic(DAOFactory parameter, IViewsCollections _viewsCollections) : this(parameter)
        {
            viewsCollections = _viewsCollections;
        }
        public StockLogic(DAOFactory parameter) : base(parameter.stockDAO)
        {
        }
       
        public bool searchLogic(StockView element, string parameter)
        {
            return
                element.IdStock.ToString().Contains(parameter.Trim()) ||
                element.Name.ToLower().StartsWith(parameter.Trim().ToLower()) ||
                element.Presentation.ToLower().StartsWith(parameter.Trim().ToLower());
        }

        public Stock getStock(int id)
        {
            return ((StockDAO)_dao).GetStock(id);
        }

        public bool hasChangeableState(int id)
        {
            var element = getStock(id);
            return element.ProductNavigation.Status && element.PresentationNavigation.Status;
        }
    }
}
