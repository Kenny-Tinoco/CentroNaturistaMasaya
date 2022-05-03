using DataAccess.SqlServerDataSource;
using Domain.DAO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DaoSqlServer
{
    public abstract class BaseDAOSQL<Entity> : BaseDAO<Entity, object> where Entity : BaseEntity 
    {
        protected readonly MasayaNaturistCenterDataBaseFactory _contextFactory;

        protected BaseDAOSQL(MasayaNaturistCenterDataBaseFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public virtual async Task create(Entity element)
        {
            using (MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext())
            {
                await context.Set<Entity>().AddAsync(element);
                await context.SaveChangesAsync();
            }
        }

        public virtual async Task<bool> deleteById(object id)
        {
            using (MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext())
            {
                Entity element = await getEntityById(id, context);

                context.Set<Entity>().Remove(element);
                await context.SaveChangesAsync();

                return true;
            }
        }

        protected virtual Task<Entity> getEntityById(object id, MasayaNaturistCenterDataBase context)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<Entity>> getAll()
        {
            using (MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext())
            {
                IEnumerable<Entity> entities = await context.Set<Entity>().ToListAsync();

                return entities;
            }
        }

        public virtual async Task<Entity> read(object id)
        {
            using (MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext())
            {
                Entity element = await context.Set<Entity>().FirstOrDefaultAsync(item => validateEntity(item, id));
                
                return element = null!;
            }
        }

        protected virtual bool validateEntity(Entity item, object id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task update(Entity element)
        {
            using (MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext())
            {
                context.Set<Entity>().Update(element);
                await context.SaveChangesAsync();
            }
        }
    }
}
