using DataAccess;
using DataAccess.DaoSqlServer;
using DataAccess.SqlServerDataSource;
using Domain.DAO;
using Domain.Logic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using MVVMGenericStructure.Services;
using WPF.Services;
using Domain.Services;
using Domain.Services.Implementation;

namespace WPF.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
              
                services.AddSingleton<CloseModalNavigationService>();

                services.AddSingleton<IMessenger, Messenger>();

                services.AddSingleton<IViewsCollections, ViewsCollectionsSQL>();

                services.AddSingleton<DAOFactory, DAOFactorySQL>();

                services.AddSingleton<LogicFactory>();

                services.AddSingleton<IAuthenticationService, AuthenticationService>(s =>
                {
                    return new AuthenticationService(s.GetRequiredService<DAOFactory>().accountDAO);
                }); 
                
                services.AddSingleton<IBuyStockService, BuyStockService>(s =>
                {
                    return new BuyStockService(s.GetRequiredService<DAOFactory>().sellDAO);
                });

                services.AddSingleton<IAuthenticator, Authenticator>();
            });

            return host;
        }
    }
}
