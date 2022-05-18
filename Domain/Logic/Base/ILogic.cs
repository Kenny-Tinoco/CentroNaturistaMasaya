using Domain.Entities;

namespace Domain.Logic.Base
{
    public interface ILogic
    {
        Task Create();
        Task Edit();
        Task Delete(int id);
        Task<BaseEntity?> GetById(int id);
        Task<IEnumerable<BaseEntity>> GetAll();
        Task<IEnumerable<BaseEntity>> GetActives();
        Task<IEnumerable<BaseEntity>> GetInactives();
    }
}
