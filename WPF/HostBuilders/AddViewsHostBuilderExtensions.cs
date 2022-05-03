using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WPF.View;
using WPF.ViewModel.Components;

namespace WPF.HostBuilders
{
    public static class AddViewsHostBuilderExtensions
    {
        public static IHostBuilder AddViews(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton
                (   
                    s => new Startup()
                    {
                        DataContext = s.GetRequiredService<StartupViewModel>()
                    }
                );
            });

            return host;
        }
    }
}
