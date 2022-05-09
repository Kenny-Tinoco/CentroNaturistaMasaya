using DataAccess.SqlServerDataSource;
using Domain.DAO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DaoSqlServer
{
    public class ConsultDAOSQL : BaseDAOSQL<Consult>, ConsultDAO
    {
        public ConsultDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext){}
    }

    public class EmployeeDAOSQL : BaseDAOSQL<Employee>, EmployeeDAO
    {
        public EmployeeDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }
    }

    public class PatientDAOSQL : BaseDAOSQL<Patient>, PatientDAO
    {
        public PatientDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }
    }

    public class PrescriptionProductDAOSQL : BaseDAOSQL<PrescriptionProduct>, PrescriptionProductDAO
    {
        public PrescriptionProductDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }
    }

    public class PresentationDAOSQL : BaseDAOSQL<Presentation>, PresentationDAO
    {
        public PresentationDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) {}

        protected override bool validateEntity(Presentation item, object id)
        {
            if(item.IdPresentation == (int)id)
                return true;

            return false;
        }
        protected override async Task<Presentation> getEntityById(object id, MasayaNaturistCenterDataBase context)
        {
            return await context.Set<Presentation>().FirstOrDefaultAsync((e) => e.IdPresentation == (int)id);
        }
    }

    public class ProductDAOSQL : BaseDAOSQL<Product>, ProductDAO
    {
        public ProductDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }

        protected override bool validateEntity(Product item, object id)
        {
            if (item.IdProduct == (int)id)
                return true;

            return false;
        }
        protected override async Task<Product> getEntityById(object id, MasayaNaturistCenterDataBase context)
        {
            return await context.Set<Product>().FirstOrDefaultAsync((e) => e.IdProduct == (int)id);
        }
    }

    public class ProviderDAOSQL : BaseDAOSQL<Provider>, ProviderDAO
    {
        public ProviderDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }
    }

    public class SaleDetailDAOSQL : BaseDAOSQL<SaleDetail>, SaleDetailDAO
    {
        public SaleDetailDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }
    }

    public class SellDAOSQL : BaseDAOSQL<Sell>, SellDAO
    {
        public SellDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }
    }
    
    public class StockDAOSQL : BaseDAOSQL<Stock>, StockDAO
    {
        public StockDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }
        
        protected override bool validateEntity(Stock item, object id)
        {
            if (item.IdStock == (int)id)
                return true;

            return false;
        }
        protected override async Task<Stock> getEntityById(object id, MasayaNaturistCenterDataBase context)
        {
            return await context.Set<Stock>().FirstOrDefaultAsync((e) => validateEntity(e, id));
        }

        public Stock getStock(int id)
        {
            using (MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext())
            {
                var element = context.Stocks.Single(item => item.IdStock == id);

                context.Entry(element).Reference(s => s.ProductNavigation).Load();
                context.Entry(element).Reference(s => s.PresentationNavigation).Load();

                return element;
            }
        }
    }

    public class SupplyDAOSQL : BaseDAOSQL<Supply>, SupplyDAO
    {
        public SupplyDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }
    }

    public class SupplyDetailDAOSQL : BaseDAOSQL<SupplyDetail>, SupplyDetailDAO
    {
        public SupplyDetailDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }
    }
}
