using Domain.DAO;
using Domain.Entities;

namespace Domain.Logic
{
    public class BaseLogic<Entity> where Entity : BaseEntity
    {
        protected BaseDAO<Entity, object> _dao;

        public BaseLogic(BaseDAO<Entity, object> parameter)
        {
            _dao = parameter;
        }


        public async Task save()
        {
            await _dao.create(entity);
            resetEntity();
        }

        public async Task edit()
        {
            await _dao.update(entity);
            resetEntity();
        }

        public async Task delete(Entity parameter)
        {
            await _dao.deleteById(getId(parameter));
        }

        public virtual int getId(Entity parameter)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Entity> getById(object parameter)
        {
            return await _dao.read(parameter);
        }

        public async Task<IEnumerable<Entity>> getAll()
        {
            return await _dao.getAll();
        }

        public Entity entity { get; set; }

        public virtual void resetEntity() {}
    }
}
