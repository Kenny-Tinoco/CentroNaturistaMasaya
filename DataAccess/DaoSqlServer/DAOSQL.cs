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
            if(item.idPresentation == (int)id)
                return true;

            return false;
        }
        protected override async Task<Presentation> getEntityById(object id, MasayaNaturistCenterDataBase context)
        {
            return await context.Set<Presentation>().FirstOrDefaultAsync((e) => e.idPresentation == (int)id);
        }
    }

    public class ProductDAOSQL : BaseDAOSQL<Product>, ProductDAO
    {
        public ProductDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }

        protected override bool validateEntity(Product item, object id)
        {
            if (item.idProduct == (int)id)
                return true;

            return false;
        }
        protected override async Task<Product> getEntityById(object id, MasayaNaturistCenterDataBase context)
        {
            return await context.Set<Product>().FirstOrDefaultAsync((e) => e.idProduct == (int)id);
        }
    }

    public class ProviderDAOSQL : BaseDAOSQL<Provider>, ProviderDAO
    {
        public ProviderDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }
    }

    public class SaleDetailDAOSQL : BaseDAOSQL<TransactionDetail>, TransactionDetailDAO
    {
        public SaleDetailDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }
    }

    public class SellDAOSQL : BaseDAOSQL<Transaction>, TransactionDAO
    {
        public SellDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }
    }
    
    public class StockDAOSQL : BaseDAOSQL<Stock>, StockDAO
    {
        public StockDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }
    }

    public class SupplyDAOSQL : BaseDAOSQL<Transaction>, TransactionDAO
    {
        public SupplyDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }
    }

    public class SupplyDetailDAOSQL : BaseDAOSQL<TransactionDetail>, TransactionDetailDAO
    {
        public SupplyDetailDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }
    }
}
