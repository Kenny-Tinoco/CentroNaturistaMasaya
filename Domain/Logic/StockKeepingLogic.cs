using Domain.DAO;
using Domain.Entities;
using Domain.Logic.Base;

namespace Domain.Logic
{
    public class StockKeepingLogic : BaseLogic<StockKeeping>
    {
        public StockKeepingLogic(DAOFactory parameter) : base(parameter.stockKeepingDAO)
        {
        }
    }
}
