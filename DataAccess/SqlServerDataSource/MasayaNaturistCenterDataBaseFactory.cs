using Microsoft.EntityFrameworkCore;

namespace DataAccess.SqlServerDataSource
{
    public class MasayaNaturistCenterDataBaseFactory
    {
       private readonly Action<DbContextOptionsBuilder> _configureDbContext = null!;

        public MasayaNaturistCenterDataBaseFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }
        public MasayaNaturistCenterDataBaseFactory()
        { 
        }
        public MasayaNaturistCenterDataBase CreateDbContext()
        {
            DbContextOptionsBuilder<MasayaNaturistCenterDataBase> options = new DbContextOptionsBuilder<MasayaNaturistCenterDataBase>();

            _configureDbContext(options);

            return new MasayaNaturistCenterDataBase(options.Options);
        }
    }
}
