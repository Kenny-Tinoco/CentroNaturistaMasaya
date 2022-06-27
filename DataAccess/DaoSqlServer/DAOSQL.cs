using DataAccess.SqlServerDataSource;
using Domain.DAO;
using Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.DaoSqlServer
{
    public class AccountDAOSQL : BaseDAOSQL<Account>, AccountDAO
    {
        public AccountDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext)
        {
        }

        public async Task<Account?> GetByUserName(string userName)
        {
            using MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext();

            return await context.Accounts
                .Include(a => a.EmployeeNavigation)
                .FirstOrDefaultAsync(a => a.UserName == userName);
        }

        public async Task<bool> VerifyPassword(string userName, string password)
        {
            using MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext();

            var result = new SqlParameter
            {
                ParameterName = "result",
                SqlDbType = System.Data.SqlDbType.Bit,
                Direction = System.Data.ParameterDirection.Output
            };

            await context.Database.ExecuteSqlRawAsync($"EXEC @result = [dbo].[sp_VerifyPassword] {userName}, {password}", result);

            return (bool)result.Value;
        }

        public override async Task Create(Account element) => await CreateAndUpdateAccount(element, 0);

        public override async Task Update(Account element) => await CreateAndUpdateAccount(element, 1);

        private async Task CreateAndUpdateAccount(Account element, int operation)
        {
            if (element is null)
                return;

            using MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext();

            await context
                .Database
                .ExecuteSqlRawAsync
                (
                    $"EXEC [dbo].[sp_AddOrUpdateAccount] " +
                    $"{element.IdAccount}, " +
                    $"{element.IdEmployee} " +
                    $"{element.UserName} " +
                    $"{element.Password} " +
                    $"{element.Created} " +
                    $"{operation}"
                );
        }
    }

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

        public override async Task<IEnumerable<Presentation>> GetAll()
        {
            return (await GetAllPresentations()).Where(item => item.IdPresentation != 11);
        }

        public async Task<IEnumerable<Presentation>> GetAllPresentations()
        {
            using MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext();
            IEnumerable<Presentation> entities = await context.Set<Presentation>().ToListAsync();

            return entities;
        }
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

        public override async Task<IEnumerable<Provider>> GetAll()
        {
            using MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext();
            IEnumerable<Provider> entities = await context
                .Providers
                .Include(x => x.ProviderPhones)
                .ToListAsync();

            return entities;
        }
    }

    public class ProviderPhoneDAOSQL : BaseDAOSQL<ProviderPhone>, ProviderPhoneDAO
    {
        public ProviderPhoneDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext)
        { }

        public async Task<IEnumerable<ProviderPhone>> GetWhere(int id)
        {
            using MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext();
            IEnumerable<ProviderPhone> entities = await context
                .Set<ProviderPhone>()
                .Where(item => item.IdProvider == id)
                .ToListAsync();

            return entities;
        }
        public override async Task<bool> DeleteById(object id)
        {
            using MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext();
            ProviderPhone element = await Read(id);

            if (element is null)
                throw new ArgumentException(nameof(element));

            context.Set<ProviderPhone>().Remove(element);
            context.SaveChanges();

            return true;
        }
    }

    public class SaleDetailDAOSQL : BaseDAOSQL<SaleDetail>, SaleDetailDAO
    {
        public SaleDetailDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext)
        {
        }

        public async Task Create(IEnumerable<SaleDetail> elements)
        {
            using MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext();
            
            await context.Set<SaleDetail>().AddRangeAsync(elements);
            await context.SaveChangesAsync();
        }
    }

    public class SaleDAOSQL : BaseDAOSQL<Sale>, SaleDAO
    {
        public SaleDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) 
        {
        }

        protected override string nameTable => "Sell";

        public async Task<int> GetLastedId()
        {
            using MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext();

            if (nameTable is null)
                throw new ArgumentException(nameof(nameTable));

            var result = new SqlParameter
            {
                ParameterName = "result",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };

            await context.Database.ExecuteSqlRawAsync($"EXEC @result = [dbo].[sp_GetLastedId] {nameTable}", result);

            return (int)result.Value;
        }
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

    public class StockKeepingDAOSQL : BaseDAOSQL<StockKeeping>, StockKeepingDAO
    {
        public StockKeepingDAOSQL(MasayaNaturistCenterDataBaseFactory dataBaseContext) : base(dataBaseContext) { }
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
