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
        private readonly IGameCatalogApiService catalogApiService;

        public int Page { get; set; } = 1;
        public DelegateCommand PreviousPageCommand => new DelegateCommand(PreviousPage);
        public DelegateCommand NextPageCommand => new DelegateCommand(NextPage);
        public DelegateCommand GameDetailPageCommand => new DelegateCommand(GameDetail);
        public IList<Game> GameLists { get; set; }
        public Game SelectedGame { get; set; }

        public CatalogViewModel(INavigationService navigationService, IPageDialogService dialogService, 
            IGameCatalogApiService gameCatalogApiService, GenresApiService genresService) : base(navigationService, dialogService)
        {
            catalogApiService = gameCatalogApiService;
            genreApiService = genresService;
            LoadCatalog(GenresList);
            LoadGenres();
        }

        public async void LoadCatalog(IList<Genre> genres)
        {
            if(!ThereIsInternetAccess())
            {
                await dialogService.DisplayAlertAsync(Titles.Error, ErrorMessages.NoInternetAccess, AlertButtonMessages.Dismiss);
                return;
            }

            var gameList = await catalogApiService.GetPageAsync(Page, genres);
            GameLists = gameList;
        }
        public async void GameDetail()
        {
            var navParameters = new NavigationParameters();
            navParameters.Add("Game", SelectedGame);
            await navigationService.NavigateAsync("GameDetailPage", navParameters);
        }
        public void PreviousPage()
        {
            if (Page > 1)
            {
                Page--;
                LoadCatalog(FilteredGenres());
            }
        }
        public void NextPage()
        {
            Page++;
            LoadCatalog(FilteredGenres());
        }

        //MASTER VIEW MODEL
        private readonly IGenresApiService genreApiService;
        private IList<object> selectedGenres = new ObservableCollection<object>();

        public IList<Genre> GenresList { get; set; }
        public IList<object> SelectedGenres
        {
            set
            {
                selectedGenres = value;
            }
            get => selectedGenres;
        }

        public DelegateCommand FilterCommand => new DelegateCommand(Filter);

        public async void LoadGenres()
        {
            var genreList = await genreApiService.GetGenres();
            GenresList = genreList;
        }
        public void Filter()
        {
            LoadCatalog(FilteredGenres());
        }
        public IList<Genre> FilteredGenres()
        {
            IList<Genre> genresloaded = new List<Genre>();
            foreach (object genero in selectedGenres)
            {
                genresloaded.Add((Genre)genero);
            }
            return genresloaded;
        }
    }
}
