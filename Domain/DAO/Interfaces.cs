using Domain.Entities;

namespace Domain.DAO
{
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

    public interface SellDAO : BaseDAO<Sell, object>
    {
    }

    public interface SaleDetailDAO : BaseDAO<SaleDetail, object>
    {
    }

    public interface SupplyDAO : BaseDAO<Supply, object>
    {
    }

    public interface SupplyDetailDAO : BaseDAO<SupplyDetail, object>
    {
    }
}
