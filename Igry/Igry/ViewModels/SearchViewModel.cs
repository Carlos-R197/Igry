using Igry.Constants;
using Igry.Models;
using Igry.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igry.ViewModels
{
    class SearchViewModel : BaseViewModel
    {
        public SearchViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService, dialogService){}
        SearchGamesApiService apiService = new SearchGamesApiService();
        public IList<Game> GameResults { get; set; }
        public Game SelectedGame { get; set; }
        public string Text { get; set; }
        public DelegateCommand GameDetailPageCommand => new DelegateCommand(GameDetail);
        public DelegateCommand SearchGameCommand => new DelegateCommand(SearchGame);
        public async void GameDetail()
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add("Game", SelectedGame);
            await navigationService.NavigateAsync("GameDetailPage", navigationParams);
        }
        public async void SearchGame()
        {
            if (!ThereIsInternetAccess())
            {
                await dialogService.DisplayAlertAsync(Titles.Error, ErrorMessages.NoInternetAccess, AlertButtonMessages.Dismiss);
                return;
            }

            var gameList = await apiService.SearchAsync(Text);
            GameResults = gameList;
        }
    }
}
