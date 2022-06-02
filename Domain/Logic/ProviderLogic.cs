using Domain.DAO;
using Domain.Entities;
using Domain.Logic.Base;

namespace Domain.Logic
{
    public class ProviderLogic : BaseLogic<Provider>
    {
        public ProviderLogic(DAOFactory parameter) : base(parameter.providerDAO)
        {
        }

        public static bool SearchLogic(Provider element, string parameter) => 
            element.IdProvider.ToString().Contains(parameter) ||
            element.Name.ToLower().StartsWith(parameter.ToLower());
    }
}
