using Domain.DAO;
using Domain.Entities;
using Domain.Logic.Base;

namespace Domain.Logic
{
    public class StockModalLogic : BaseLogic<Stock>
    {
        private ProductDAO productDAO;
        private PresentationDAO presentationDAO;

        public StockModalLogic( DAOFactory parameter ) : base(parameter.stockDAO)
        {
            productDAO = parameter.productDAO;
            presentationDAO = parameter.presentationDAO;
        }
    }
}
