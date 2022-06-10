using Domain.DAO;
using Domain.Entities;
using Domain.Entities.Views;
using Domain.Logic.Base;
using Domain.Services;

namespace Domain.Logic
{
    public class SaleLogic : BaseLogic<Sale>
    {
        private readonly DAOFactory daoFactory = null!;
        public IViewsCollections viewsCollections = null!;

        public SaleLogic(DAOFactory parameter, IViewsCollections _viewsCollections) : this(parameter)
        {
            viewsCollections = _viewsCollections;
        }

        public SaleLogic(DAOFactory parameter) : base(parameter.sellDAO)
        {
            entity = new Sale();
            daoFactory = parameter;
        }


        public async Task<IEnumerable<SaleDetailView>> GetDetails(int idSell)
        {
            var list = await viewsCollections.SaleDetailViewCatalog();

            List<SaleDetailView> elements = new();

            foreach (var item in list)
                if (item.IdSale == idSell)
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

        public async Task<bool> VerifyStockQuantity(int quantityyOnResquest, int idStock)
        {
            var entity = await daoFactory.stockDAO.Read(idStock);

            if (entity is null)
                return false;

            if (quantityyOnResquest > entity.Quantity)
                return false;

            return true;
        }

        public async Task<int> GetLastedIdSell() => await daoFactory.sellDAO.GetLastedId();

        public static bool SearchLogic(SaleView element, string parameter) =>
            element.IdEmployee.ToString().Contains(parameter) ||
            element.Name.ToLower().StartsWith(parameter.ToLower());
    }
}
