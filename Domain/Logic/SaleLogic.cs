using Domain.DAO;
using Domain.Entities;
using Domain.Entities.Views;
using Domain.Logic.Base;
using Domain.Services;
using Domain.Utilities;

namespace Domain.Logic
{
    public class SaleLogic : BaseLogic<Sell>
    {
        private readonly DAOFactory daoFactory = null!;
        public IViewsCollections viewsCollections = null!;
        
        public SaleLogic(DAOFactory parameter, IViewsCollections _viewsCollections) : this(parameter)
        {
            viewsCollections = _viewsCollections;
        }

        public SaleLogic(DAOFactory parameter) : base(parameter.sellDAO)
        {
            entity = new Sell();
            daoFactory = parameter;
        }


        public async Task<IEnumerable<SaleDetailView>> GetDetails(int idSell)
        {
            var list = await viewsCollections.SaleDetailViewCatalog();

            List<SaleDetailView> elements = new();

            foreach (var item in list)
                if (item.IdSell == idSell)
                    elements.Add(item);

            return elements;
        }

        public async Task<IEnumerable<StockView>> GetStockListing()
        {
            var list = await viewsCollections.StockViewCatalog(Views.OnlyActive); 
            
            List<StockView> elements = new();

            foreach (var item in list)
                if (item.Quantity > 0)
                    elements.Add(item);

            return elements;
        }
        
        public async Task<IEnumerable<Presentation>> GetPresentationListing() => await daoFactory.presentationDAO.GetActives();

        public async Task<bool> VerifyStockQuantity(int quantityyOnResquest, int idStock)
        {
            var entity = await daoFactory.stockDAO.Read(idStock);

            if (entity is null)
                return false;

            if (quantityyOnResquest > entity.Quantity)
                return false;

            return true;
        }

        public async Task CreateDetail(IEnumerable<SaleDetail> detail)
        {
            if (detail is null)
                throw new ArgumentNullException(nameof(detail));

            try
            {
                await daoFactory.saleDetailDAO.Create(detail);
            }
            catch (Exception) 
            {
                throw new ArgumentException(nameof(CreateDetail));
            }
        }

        public async Task<int> GetLastedIdSell()
        {
            return await daoFactory.sellDAO.GetLastedId();
        }

        public static bool SearchLogic(SellView element, string parameter) => 
            element.IdEmployee.ToString().Contains(parameter) ||
            element.Name.ToLower().StartsWith(parameter.ToLower());
    }
}
