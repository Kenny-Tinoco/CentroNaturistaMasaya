namespace Domain.Services
{
    public interface IDataService<T, ID>
    {
        Task Create(T element);
        Task<T?> Read(ID id);
        Task Update(T element);
        Task<bool> DeleteById(ID id);
        Task<IEnumerable<T>> GetAll();
    }
}
