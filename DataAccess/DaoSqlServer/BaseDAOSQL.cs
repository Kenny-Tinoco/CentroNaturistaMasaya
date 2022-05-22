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

        public virtual async Task Create(Entity element)
        {
            using MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext();
            await context.Set<Entity>().AddAsync(element);
            await context.SaveChangesAsync();
        }

        public virtual async Task<bool> DeleteById(object id)
        {
            using MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext();
            Entity element = await Read(id);

            if (element is null)
                throw new ArgumentException(nameof(element));

            context.Set<Entity>().Remove(element);
            await context.SaveChangesAsync();

            return true;
        }

        public virtual async Task<IEnumerable<Entity>> GetAll()
        {
            using MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext();
            IEnumerable<Entity> entities = await context.Set<Entity>().ToListAsync();

            return entities;
        }

        public virtual async Task<Entity?> Read(object id)
        {
            using MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext();
            
            return await context.Set<Entity>().FindAsync((int)id);
        }

        public virtual async Task Update(Entity element)
        {
            using MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext();
            
            context.Set<Entity>().Update(element);
            await context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<Entity>> GetActives()
        {
            using MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext();
            
            if (nameTable is null)
                throw new ArgumentException(nameof(nameTable));

            IEnumerable<Entity> entities = await context.Set<Entity>()
                .FromSqlInterpolated($"EXECUTE dbo.sp_GetActives {nameTable}")
                .ToListAsync();

            return entities;
        }

        public virtual async Task<IEnumerable<Entity>> GetInactives()
        {
            using MasayaNaturistCenterDataBase context = _contextFactory.CreateDbContext();
            
            if (nameTable is null)
                throw new ArgumentException(nameof(nameTable));

            IEnumerable<Entity> entities = await context.Set<Entity>()
                .FromSqlInterpolated($"EXECUTE dbo.sp_GetInactives {nameTable}")
                .ToListAsync();

            return entities;
        }

        protected virtual string nameTable { get; set; } = null!;
    }
}
