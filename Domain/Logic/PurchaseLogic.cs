using Domain.DAO;
using Domain.Entities;
using Domain.Entities.Views;
using Domain.Logic.Base;
using Domain.Services;

namespace Domain.Logic
{
    public class PurchaseLogic : BaseLogic<Supply>
    {
        private readonly DAOFactory daoFactory = null!;
        public IViewsCollections viewsCollections = null!;

        public PurchaseLogic(DAOFactory parameter, IViewsCollections _viewsCollections) : this(parameter)
        {
            viewsCollections = _viewsCollections;
        }

        public PurchaseLogic(DAOFactory parameter) : base(parameter.supplyDAO)
        {
            entity = new Supply();
            daoFactory = parameter;
        }


        public async Task<IEnumerable<SupplyDetailView>> GetDetails(int idSupply)
        {
            var list = await viewsCollections.SupplyDetailViewCatalog();

            List<SupplyDetailView> elements = new();

            foreach (var item in list)
                if (item.IdSupply == idSupply)
                    elements.Add(item);

            return elements;
        }

        public async Task<IEnumerable<(string name, int idEmployee)>> GetEmployees()
        {
            var list = await daoFactory.employeeDAO.GetActives();

            List<(string, int)> result = new();

            result.Add(("Todos los empleados", -1));
            foreach (var o in list)
                result.Add((o.Name + " " + o.LastName, o.IdEmployee));

            return result;
        }
        public async Task<IEnumerable<(string name, int idProvider)>> GetProviders()
        {
            var list = await daoFactory.providerDAO.GetActives();

            List<(string, int)> result = new();

            result.Add(("Todos los proveedores", -1));
            foreach (var o in list)
                result.Add((o.Name, o.IdProvider));

            return result;
        }

        public async Task<bool> VerifyStockQuantity(int quantityyOnResquest, int idStock)
        {
            var entity = await daoFactory.stockDAO.Read(idStock);

            if (entity is null)
                return false;

            if (quantityyOnResquest > entity.Quantity)
                return false;

            return true;
        }

        public static bool SearchLogic(SupplyView element, string parameter) =>
            element.IdProvider.ToString().Contains(parameter) ||
            element.Name.ToLower().StartsWith(parameter.ToLower());
    }
}
