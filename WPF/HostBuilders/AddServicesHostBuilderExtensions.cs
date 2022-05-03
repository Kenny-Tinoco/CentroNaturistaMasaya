using DataAccess;
using DataAccess.DaoSqlServer;
using DataAccess.SqlServerDataSource;
using Domain.DAO;
using Domain.Logic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using MVVMGenericStructure.Services;

namespace WPF.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<DAOFactory>(createDAOFactorySQL);

                services.AddSingleton<LogicFactory>(createLogicFactory);
              
                services.AddSingleton<CloseModalNavigationService>();
            });

            return host;
        }
        private static DAOFactory createDAOFactorySQL(IServiceProvider serviceProvider)
        {
            return new DAOFactorySQL(serviceProvider.GetRequiredService<MasayaNaturistCenterDataBaseFactory>());
        }
        private static LogicFactory createLogicFactory(IServiceProvider serviceProvider)
        {
            return new LogicFactory
            (
                serviceProvider.GetRequiredService<DAOFactory>(),
                new ViewsCollectionsSQL(serviceProvider.GetRequiredService<MasayaNaturistCenterDataBaseFactory>())
            );
        }
    }
}
