using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;

using Igry.ViewModels;
using Igry.Views;
using Igry.Services;
using System.IO;

using Igry.Models;
using System.Collections.ObjectModel;
using Igry.Constants;

namespace Igry
{
    public partial class App : PrismApplication
    {
        private const string databaseName = "myDB.db3";

        public App(IPlatformInitializer initializer = null) : base(initializer) 
        { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync($"{PageName.NavigationPage}/{PageName.LoginPage}");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), databaseName));
            var user = new User();
            var favoriteGames = new ObservableCollection<Game>();
            containerRegistry.RegisterInstance(database);
            containerRegistry.RegisterInstance(user);
            containerRegistry.RegisterInstance(favoriteGames);

            containerRegistry.Register<GameOfTheMonthApiService>();
            containerRegistry.Register<GamesByIdApiService>();
            containerRegistry.Register<RecommendedGamesApiService>();
            containerRegistry.Register<IGenresApiService, GenresApiService>();
            containerRegistry.Register<SearchGamesApiService>();
            containerRegistry.Register<IGameCatalogApiService, GameCatalogApiService>();
            containerRegistry.Register<OpenUrlService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterViewModel>();
            containerRegistry.RegisterForNavigation<GameDetailPage, GameDetailViewModel>();
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsViewModel>();
            containerRegistry.RegisterForNavigation<CatalogPage, CatalogViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomeViewModel>();
            containerRegistry.RegisterForNavigation<HomeTabbedPage>();
            containerRegistry.RegisterForNavigation<SearchPage, SearchViewModel>();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        
    }
}
