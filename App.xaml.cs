﻿using MasayaNaturistCenter.Model.DAO;
using MasayaNaturistCenter.Model.Entities;
using MasayaNaturistCenter.View;
using MasayaNaturistCenter.ViewModel;
using MasayaNaturistCenter.ViewModel.Services;
using MasayaNaturistCenter.ViewModel.Stores;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace MasayaNaturistCenter
{
    public partial class App : Application
    {

        private readonly IServiceProvider _serviceProvider;
        private readonly MasayaNaturistCenterDataBase dataBaseContext;


        public App()
        {
            dataBaseContext = new MasayaNaturistCenterDataBase();
            IServiceCollection services = new ServiceCollection();

            addServices(services);

            _serviceProvider = services.BuildServiceProvider();
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();

            MainWindow = _serviceProvider.GetRequiredService<Startup>();
            MainWindow.Show();

            base.OnStartup(e);
        }


        private void addServices(IServiceCollection services)
        {
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<ModalNavigationStore>();
            services.AddSingleton<MasayaNaturistCenterDataBase>();
            services.AddSingleton<IStockDAO>(s => createStockDAO(s));
            services.AddSingleton<StockViewModelRecords>();
            services.AddSingleton<StockViewModel>();
            services.AddSingleton<HomeViewModel>(s => new HomeViewModel(createProductNavigationService(s)));

            services.AddSingleton<INavigationService>(s => createHomeNavigationService(s));

            services.AddTransient<NavigationMenuViewModel>(createNavigationMenuViewModel);

            services.AddSingleton<StartupViewModel>();
            services.AddSingleton
            (
                s => new Startup()
                {
                    DataContext = s.GetRequiredService<StartupViewModel>()
                }
            );
        }

        private IStockDAO createStockDAO(IServiceProvider serviceProvider)
        {
            return new StockDAO(serviceProvider.GetRequiredService<MasayaNaturistCenterDataBase>());
        }

        private StockViewModel createStockViewModel(IServiceProvider serviceProvider)
        {
            return new StockViewModel
            (
                createStockViewModelRecord(serviceProvider)
            );
        }

        private StockViewModelRecords createStockViewModelRecord(IServiceProvider serviceProvider)
        {
            return new StockViewModelRecords(serviceProvider.GetRequiredService<IStockDAO>(), createHomeNavigationService(serviceProvider));
        }

        private NavigationMenuViewModel createNavigationMenuViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationMenuViewModel
            (
                createHomeNavigationService(serviceProvider),
                createProductNavigationService(serviceProvider)
            );
        }

        private INavigationService createProductNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<StockViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<StockViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationMenuViewModel>()
            );
        }

        private INavigationService createHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<HomeViewModel>
            (
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<HomeViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationMenuViewModel>()
            );
        }
    }
}
