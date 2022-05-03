using Domain.DAO;
using Domain.Entities;
using Domain.Entities.Views;
using Domain.Services;
using System.Diagnostics.Contracts;

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
            Contract.Requires(parameter != null && element != null);

            return
                element.idStock.ToString().Contains(parameter.Trim()) ||
                element.name.ToLower().StartsWith(parameter.Trim().ToLower()) ||
                element.presentation.ToLower().StartsWith(parameter.Trim().ToLower());
        }
    }
}
