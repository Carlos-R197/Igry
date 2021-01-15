using Igry.Constants;
using Igry.Models;
using Igry.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Igry.ViewModels
{
    class CatalogViewModel : BaseViewModel
    {
        public int Page { get; set; } = 1;
        IGameCatalogApiService apiService = new GameCatalogApiService();
        public DelegateCommand PreviousPageCommand => new DelegateCommand(PreviousPage);
        public DelegateCommand NextPageCommand => new DelegateCommand(NextPage);
        public DelegateCommand GameDetailPageCommand => new DelegateCommand(GameDetail);
        public IList<Game> GameLists { get; set; }
        public Game SelectedGame { get; set; }

        public async void LoadCatalog(int page)
        {
            if(!ThereIsInternetAccess())
            {
                await dialogService.DisplayAlertAsync(Titles.Error, ErrorMessages.NoInternetAccess, AlertButtonMessages.Dismiss);
                return;
            }

            var gameList = await apiService.GetPageAsync(page);
            GameLists = gameList;
        }
        public async void GameDetail()
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add("Game", SelectedGame);
            await navigationService.NavigateAsync("GameDetailPage", navigationParams);
        }
        public void PreviousPage()
        {
            if (Page > 1)
            {
                Page--;
                LoadCatalog(Page);
            }
        }
        public void NextPage()
        {
            Page++;
            LoadCatalog(Page);
        }
        public CatalogViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService, dialogService)
        {
            LoadCatalog(Page);
        }
    }
}
