using Igry.Models;
using Igry.Services;
using Prism.Commands;
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
        public IList<Game> GameLists { get; set; }
        public async void LoadCatalog(int page)
        {
            var gameList = await apiService.GetPageAsync(page);
            GameLists = gameList;
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
        public CatalogViewModel()
        {
            LoadCatalog(Page);
        }
    }
}
