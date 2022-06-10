using DataAccess;
using DataAccess.DaoSqlServer;
using Domain.DAO;
using Domain.Logic;
using Domain.Services;
using Domain.Services.Implementation;
using Domain.Services.TransactionServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVMGenericStructure.Services;
using WPF.Services;

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

                services.AddSingleton<ISellStockService, SellStockService>(s =>
                {
                    return new SellStockService(s.GetRequiredService<DAOFactory>().sellDAO);
                });

                services.AddSingleton<IBuyStockService, BuyStockService>(s =>
                {
                    return new BuyStockService(s.GetRequiredService<DAOFactory>().supplyDAO);
                });

                services.AddSingleton<IAuthenticator, Authenticator>();
            });

            return host;
        }
    }
}
