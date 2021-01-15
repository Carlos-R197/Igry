using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Igry.Constants;
using Igry.Models;
using Igry.Services;
using Prism;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace Igry.ViewModels
{
    public class HomeViewModel : BaseViewModel, IInitialize, INavigationAware
    {
        private readonly GameOfTheMonthApiService gameOfTheMonthApiService;
        private readonly GamesByIdApiService gamesApiService;
        private readonly RecommendedGamesApiService recommendedGamesApiService;
        private readonly DelegateCommand selectedGameCommand;
        private readonly DelegateCommand recommendedGameSelectedCommand;
        private readonly User currentUser;

        public Game GameOfTheWeek { get; private set; }
        public ObservableCollection<Game> FavoriteGames { get; private set; }
        public ObservableCollection<Game> RecommendedGames { get; private set; }
        public Game SelectedFavoriteGame { get; set; }
        public Game SelectedRecommendedGame { get; set; }
        public DelegateCommand SelectedGameCommand => selectedGameCommand;
        public DelegateCommand RecommendedGameSelectedCommand => recommendedGameSelectedCommand;


        public HomeViewModel(INavigationService navigationService, IPageDialogService dialogService, GameOfTheMonthApiService getGameApiService, 
            GamesByIdApiService gamesApiService, RecommendedGamesApiService recommendedGames, User user, ObservableCollection<Game> favoriteGames)
            : base(navigationService, dialogService)
        {
            this.gameOfTheMonthApiService = getGameApiService;
            this.gamesApiService = gamesApiService;
            this.recommendedGamesApiService = recommendedGames;


            this.selectedGameCommand = new DelegateCommand(ShowSelectedFavoriteGameDetails);
            this.recommendedGameSelectedCommand = new DelegateCommand(ShowSelectedRecommendedGameDetails);
            this.currentUser = user;

            this.FavoriteGames = favoriteGames;
            this.RecommendedGames = new ObservableCollection<Game>();
        }

        public async void Initialize(INavigationParameters parameters)
        {
            if (ThereIsInternetAccess())
            {
                LoadFavoriteGamesAsync();
                LoadRecommendedGamesAsync();
                GameOfTheWeek = await gameOfTheMonthApiService.GetGameOfTheMonthAsync();
            }
            else
            {
                await dialogService.DisplayAlertAsync(Titles.Error, ErrorMessages.NoInternetAccess, AlertButtonMessages.Dismiss);
            }
            
        }

        public async Task LoadFavoriteGamesAsync()
        {
            bool noFavorites = currentUser.Favorites.Count == 0;
            if (noFavorites)
                return;

            FavoriteGames.Clear();

            var ids = new List<int>();
            foreach (var favorite in currentUser.Favorites)
                ids.Add(favorite.GameId);
            IList<Game> games = await gamesApiService.GetGamesAsync(ids);

            foreach (var game in games)
                FavoriteGames.Add(game);
        }

        private async Task LoadRecommendedGamesAsync()
        {
            RecommendedGames.Clear();
            IList<Game> games = await recommendedGamesApiService.GetDefaultGamesAsync();
            foreach (var game in games)
                RecommendedGames.Add(game);
        }

        private void ShowSelectedFavoriteGameDetails()
        {
            if (SelectedFavoriteGame == null)
                return;

            var navigationParams = new NavigationParameters();
            navigationParams.Add("Game", SelectedFavoriteGame);
            navigationService.NavigateAsync(PageName.GameDetailPage, navigationParams, useModalNavigation: true, false);
        }

        private void ShowSelectedRecommendedGameDetails()
        {
            if (SelectedRecommendedGame == null)
                return; 

            var navigationParams = new NavigationParameters();
            navigationParams.Add("Game", SelectedRecommendedGame);
            navigationService.NavigateAsync(PageName.GameDetailPage, navigationParams, useModalNavigation: true, false);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
           
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            SelectedFavoriteGame = null;
            SelectedRecommendedGame = null;
        }
    }
}
