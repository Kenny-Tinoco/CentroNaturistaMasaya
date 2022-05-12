using DataAccess.SqlServerDataSource;
using Domain.Entities;
using Domain.Entities.Views;
using Domain.Services;
using Domain.Utilities;
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


        public async Task<IEnumerable<ConsultView>> ConsultationViewCatalog(Views type)
        {
            return await GetCollection<ConsultView>("ConsultView", type);
        }

        public async Task<IEnumerable<SaleDetailView>> SaleDetailViewCatalog(Views type)
        {
            return await GetCollection<SaleDetailView>("SaleDetailView", type);
        }

        public async Task<IEnumerable<SellView>> SellViewCatalog(Views type)
        {
            return await GetCollection<SellView>("SellView", type);
        }

        public async Task<IEnumerable<StockView>> StockViewCatalog(Views type)
        {
            return await GetCollection<StockView>("StockView", type);
        }

        public async Task<IEnumerable<SupplyDetailView>> SupplyDetailViewCatalog(Views type)
        {
            return await GetCollection<SupplyDetailView>("SupplyDetailView", type);
        }

        public async Task<IEnumerable<SupplyView>> SupplyViewCatalog(Views type)
        {
            return await GetCollection<SupplyView>("SupplyView", type);
        }



        private async Task<IEnumerable<Entity>> GetCollection<Entity>(string nameTable, Views type) where Entity : BaseEntity
        {
            using (MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext())
            {
                if (nameTable is null)
                    throw new ArgumentException(nameof(nameTable));

                IEnumerable<Entity> entities; 

                if(type is Views.All)
                {
                    entities = await context.Set<Entity>().ToListAsync();
                }
                else if(type is Views.OnlyActive)
                {
                    entities = await context.Set<Entity>()
                    .FromSqlInterpolated($"EXECUTE dbo.sp_GetActives {nameTable}")
                    .ToListAsync();
                }
                else
                {
                    entities = await context.Set<Entity>()
                    .FromSqlInterpolated($"EXECUTE dbo.sp_GetInactives {nameTable}")
                    .ToListAsync();

                }


                return entities;
            }
        }
    }
}
