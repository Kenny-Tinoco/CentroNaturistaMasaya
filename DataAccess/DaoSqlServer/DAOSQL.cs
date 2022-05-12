using DataAccess.SqlServerDataSource;
using Domain.DAO;
using Domain.Entities;

namespace DataAccess.DaoSqlServer
{
    public class ConsultDAOSQL : BaseDAOSQL<Consult>, ConsultDAO
    {
        public ConsultDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }
    }

    public class EmployeeDAOSQL : BaseDAOSQL<Employee>, EmployeeDAO
    {
        public EmployeeDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }

        protected override string nameTable => "Employee";
    }

    public class PatientDAOSQL : BaseDAOSQL<Patient>, PatientDAO
    {
        public PatientDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }

        protected override string nameTable => "Patient";
    }

    public class PrescriptionProductDAOSQL : BaseDAOSQL<PrescriptionProduct>, PrescriptionProductDAO
    {
        public PrescriptionProductDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }
    }

    public class PresentationDAOSQL : BaseDAOSQL<Presentation>, PresentationDAO
    {
        public PresentationDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }

        protected override string nameTable => "Presentation";
    }

    public class ProductDAOSQL : BaseDAOSQL<Product>, ProductDAO
    {
        public ProductDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }

        protected override string nameTable => "Product";
    }

    public class ProviderDAOSQL : BaseDAOSQL<Provider>, ProviderDAO
    {
        public ProviderDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }

        protected override string nameTable => "Provider";
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

        public Stock GetStock(int id)
        {
            using (MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext())
            {
                var element = context.Stocks.Single(item => item.IdStock == id);

                context.Entry(element).Reference(s => s.ProductNavigation).Load();
                context.Entry(element).Reference(s => s.PresentationNavigation).Load();

                return element;
            }
        }
        protected override string nameTable => "Stock";
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
