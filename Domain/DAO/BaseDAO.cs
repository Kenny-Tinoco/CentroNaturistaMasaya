using Domain.Services;

namespace Domain.DAO
{
    public interface BaseDAO<T, ID> : IDataService<T, ID>
    {
        Task<IEnumerable<T>> GetActives();
        Task<IEnumerable<T>> GetInactives();
    }
}
