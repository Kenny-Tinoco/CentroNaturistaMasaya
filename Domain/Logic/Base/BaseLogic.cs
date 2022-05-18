using Domain.DAO;
using Domain.Entities;

namespace Domain.Logic.Base
{
    public class BaseLogic<Entity>: ILogic where Entity : BaseEntity
    {
        protected BaseDAO<Entity, object> _dao;
        public Entity entity { get; set; } = null!;

        public BaseLogic(BaseDAO<Entity, object> parameter)
        {
            _dao = parameter;
        }


        public async Task Create()
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

        public virtual async Task<BaseEntity?> GetById(int id)
        {
            return await _dao.Read(id);
        }

        public async Task<IEnumerable<BaseEntity>> GetAll()
        {
            return await _dao.GetAll();
        }
        
        public async Task<IEnumerable<BaseEntity>> GetActives()
        {
            return await _dao.GetActives();
        }
        
        public async Task<IEnumerable<BaseEntity>> GetInactives()
        {
            return await _dao.GetInactives();
        }

        public virtual void ResetEntity(){}
    }
}
