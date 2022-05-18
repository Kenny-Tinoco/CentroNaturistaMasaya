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

        public bool searchLogic(Provider element, string parameter)
        {
            return
                element.IdProvider.ToString().Contains(parameter.Trim()) ||
                element.Name.ToLower().StartsWith(parameter.Trim().ToLower());
        }
    }
}
