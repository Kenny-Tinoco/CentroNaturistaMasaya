using Domain.DAO;
using Domain.Entities;

namespace Domain.Logic.Base
{
    public class ProviderPhoneLogic : BaseLogic<ProviderPhone>
    {
        public ProviderPhoneLogic(DAOFactory parameter) : base(parameter.providerPhoneDAO)
        {
        }

        public Task<IEnumerable<ProviderPhone>> GetWhere(int id)
        {
            return ((ProviderPhoneDAO)_dao).GetWhere(id);
        }
    }
}
