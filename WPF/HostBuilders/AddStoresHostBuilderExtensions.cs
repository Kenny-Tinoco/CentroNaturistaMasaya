using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVVMGenericStructure.Stores;
using WPF.Stores;

namespace WPF.HostBuilders
{
    public static class AddStoresHostBuilderExtensions
    {
        public static IHostBuilder AddStores(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<NavigationStore>();
                services.AddSingleton<ModalNavigationStore>();
                services.AddSingleton<IAccountStore, AccountStore>();
            });

            return host;
        }
    }
}
