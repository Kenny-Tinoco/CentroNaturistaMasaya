using Domain.Entities;

namespace Domain.DAO
{
    public interface AccountDAO : BaseDAO<Account, object>
    {
        Task<Account?> GetByUserName(string userName);
        Task<bool> VerifyPassword(string userName, string password);
    }

    public interface ConsultDAO : BaseDAO<Consult, object> 
    {
    }

    public interface EmployeeDAO : BaseDAO<Employee, object>
    {
    }

    public interface PatientDAO : BaseDAO<Patient, object>
    {
    }

    public interface PrescriptionProductDAO : BaseDAO<PrescriptionProduct, object>
    {
    }

    public interface PresentationDAO : BaseDAO<Presentation, object>
    {
        Task<IEnumerable<Presentation>> GetAllPresentations();
    }

    public interface ProductDAO : BaseDAO<Product, object>
    {
    }

    public interface ProviderDAO : BaseDAO<Provider, object>
    {
    }
    public interface ProviderPhoneDAO : BaseDAO<ProviderPhone, object>
    {
        Task<IEnumerable<ProviderPhone>> GetWhere(int id);
    }

    public interface StockDAO : BaseDAO<Stock, object>
    {
        Stock GetStock(int id);
    }
    public interface StockKeepingDAO : BaseDAO<StockKeeping, object>
    {
    }

    public interface SaleDAO : BaseDAO<Sale, object>
    {
        Task<int> GetLastedId();
    }

    public interface SaleDetailDAO : BaseDAO<SaleDetail, object>
    {
        Task Create(IEnumerable<SaleDetail> elements);
    }

    public interface SupplyDAO : BaseDAO<Supply, object>
    {
    }

    public interface SupplyDetailDAO : BaseDAO<SupplyDetail, object>
    {
    }
}
