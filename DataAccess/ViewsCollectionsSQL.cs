using DataAccess.SqlServerDataSource;
using Domain.Entities;
using Domain.Entities.Views;
using Domain.Services;
using Domain.Utilities;
using Microsoft.Data.SqlClient;
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

        public async Task<IEnumerable<SaleDetailView>> SaleDetailViewCatalog()
        {
            return await GetCollection<SaleDetailView>("SaleDetailView", Views.All);
        }

        public async Task<IEnumerable<SaleView>> SaleViewCatalog(Periods _period, int _idEmployee)
        {
            using MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext();

            var period = new SqlParameter("period",(int)_period);
            var idEmployee = new SqlParameter("idEmployee", _idEmployee);

            return await context.SaleViews
            .FromSqlRaw("execute dbo.sp_GetSaleViewService @period, @idEmployee", period, idEmployee)
            .ToListAsync();
        }

        public async Task<IEnumerable<StockView>> StockViewCatalog(Views type)
        {
            return await GetCollection<StockView>("StockView", type);
        }

        public async Task<IEnumerable<SupplyDetailView>> SupplyDetailViewCatalog()
        {
            return await GetCollection<SupplyDetailView>("SupplyDetailView", Views.All);
        }

        public async Task<IEnumerable<SupplyView>> SupplyViewCatalog(Periods _period, int _idProvider)
        {
            using MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext();

            var period = new SqlParameter("period", (int)_period);
            var idProvider = new SqlParameter("idProvider", _idProvider);

            return await context.SupplyViews
            .FromSqlRaw("execute dbo.sp_GetSupplyViewService @period, @idProvider", period, idProvider)
            .ToListAsync();
        }



        private async Task<IEnumerable<Entity>> GetCollection<Entity>(string nameTable, Views type) where Entity : BaseEntity
        {
            using MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext();
            
            if (nameTable is null)
                throw new(nameof(nameTable));

            IEnumerable<Entity> entities;

            if (type is Views.All)
            {
                entities = await context.Set<Entity>().ToListAsync();
            }
            else if (type is Views.OnlyActive)
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
