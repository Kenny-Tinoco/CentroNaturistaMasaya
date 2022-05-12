using Domain.DAO;
using Domain.Entities;

namespace Domain.Logic
{
    public class BaseLogic<Entity> where Entity : BaseEntity
    {
        protected BaseDAO<Entity, object> _dao;
        public Entity entity { get; set; } = null!;

        public BaseLogic(BaseDAO<Entity, object> parameter)
        {
            _dao = parameter;
        }


        public async Task Save()
        {
            await _dao.Create(entity);
            ResetEntity();
        }

        public async Task Edit()
        {
            await _dao.Update(entity);
            ResetEntity();
        }

        public async Task Delete(int id)
        {
            await _dao.DeleteById(id);
        }

        public virtual async Task<Entity?> GetById(object parameter)
        {
            return await _dao.Read(parameter);
        }

        public async Task<IEnumerable<Entity>> GetAll()
        {
            return await _dao.GetAll();
        }
        
        public async Task<IEnumerable<Entity>> GetActives()
        {
            return await _dao.GetActives();
        }
        
        public async Task<IEnumerable<Entity>> GetInactives()
        {
            return await _dao.GetInactives();
        }

        public virtual void ResetEntity(){}
    }
}
