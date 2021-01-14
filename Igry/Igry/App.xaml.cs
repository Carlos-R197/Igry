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
using Igry.Objects;
using System.IO;

using Igry.Models;
using System.Collections.ObjectModel;

namespace Igry
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) 
        { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("NavigationPage/LoginPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "myDB.db3"));
            containerRegistry.RegisterInstance(database);
            containerRegistry.RegisterInstance(new User());
            containerRegistry.RegisterInstance(new ObservableCollection<Game>());

            containerRegistry.Register<IGameRandomizerApiService, GameRandomizerApiService>();
            containerRegistry.Register<IPlatformRandomizerApiService, PlatformRandomizerApiService>();
            containerRegistry.Register<GameOfTheMonthApiService>();
            containerRegistry.Register<GamesByIdApiService>();
            containerRegistry.Register<RecommendedGamesApiService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginViewModel>();
            containerRegistry.RegisterForNavigation<RegisterPage, RegisterViewModel>();
            containerRegistry.RegisterForNavigation<GameDetailPage, GameDetailViewModel>();
            containerRegistry.RegisterForNavigation<SettingsPage, SettingsViewModel>();
            containerRegistry.RegisterForNavigation<CatalogPage, CatalogViewModel>();
            containerRegistry.RegisterForNavigation<ProfilePage, ProfileViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomeViewModel>();
            containerRegistry.RegisterForNavigation<RandomPlatformPage, RandomPlatformViewModel>();
            containerRegistry.RegisterForNavigation<HomeTabbedPage>();
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
