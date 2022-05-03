using DataAccess.SqlServerDataSource;
using Domain.Entities;
using Domain.Entities.Views;
using Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ViewsCollectionsSQL : IViewsCollections
    {
        private readonly MasayaNaturistCenterDataBaseFactory _contextFactory;

        public ViewsCollectionsSQL(MasayaNaturistCenterDataBaseFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }


        public async Task<IEnumerable<ConsultView>> ConsultationViewCatalog()
        {
            return await getCollection<ConsultView>();
        }

        public async Task<IEnumerable<SaleDetailView>> SaleDetailViewCatalog()
        {
            return await getCollection<SaleDetailView>();
        }

        public async Task<IEnumerable<SellView>> SellViewCatalog()
        {
            return await getCollection<SellView>();
        }

        public async Task<IEnumerable<StockView>> StockViewCatalog()
        {
            return await getCollection<StockView>();
        }

        public async Task<IEnumerable<SupplyDetailView>> SupplyDetailViewCatalog()
        {
            return await getCollection<SupplyDetailView>();
        }

        public async Task<IEnumerable<SupplyView>> SupplyViewCatalog()
        {
            return await getCollection<SupplyView>();
        }



        private async Task<IEnumerable<Entity>> getCollection<Entity>() where Entity : BaseEntity
        {
            using (MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Entity> viewEntities = await context.Set<Entity>().ToListAsync();

                return viewEntities;
            }
        }
    }
}
