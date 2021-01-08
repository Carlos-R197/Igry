using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Igry.Models;
using Igry.Services;

namespace Igry.ViewModels
{
    public class GameDetailViewModel : BaseViewModel, INavigatedAware
    {
        IGameRandomizerApiService apiService;

        public DelegateCommand GetRandomGameCommand { get; set; }
        public Game CurrentGame { get; set; }
        public string CurrentGameGenres { get; set; }
        public string CurrentGamePlatforms { get; set; }

        public GameDetailViewModel(IGameRandomizerApiService apiService)
        {
            this.apiService = apiService;
            GetRandomGameCommand = new DelegateCommand(GetRandomGame);
        }
        //public GameDetailViewModel(IGameRandomizerApiService apiService, INavigationParameters parameters)
        //{
        //    this.apiService = apiService;
        //    GetRandomGameCommand = new DelegateCommand(GetRandomGame);
        //    OnNavigated
        //}


        async void GetRandomGame()
        {
            CurrentGame = await apiService.GetRandomAsync();
            AdjustCurrentGameGenre();
            AdjustCurrentGamePlatforms();
        }

        void AdjustCurrentGameGenre()
        {
            if (CurrentGame.Genres.Count > 0)
            {
                CurrentGameGenres = "Genres: ";
                CurrentGameGenres += CurrentGame.Genres[0].Name;
                for (int i = 1; i < CurrentGame.Genres.Count; i++)
                    CurrentGameGenres += ", " + CurrentGame.Genres[i].Name;
            }
        }

        void AdjustCurrentGamePlatforms()
        {
            CurrentGamePlatforms = "";
            if (CurrentGame.Platforms.Count > 0)
            {
                CurrentGamePlatforms += CurrentGame.Platforms[0].PlatformData.Name;
                for (int i = 1; i < CurrentGame.Platforms.Count; i++)
                    CurrentGamePlatforms += ", " + CurrentGame.Platforms[i].PlatformData.Name;
            }
            else
                CurrentGamePlatforms = "No platform data available for this game";
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {}

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var game = parameters.GetValue<Game>("Game");
            CurrentGame = game;
            AdjustCurrentGameGenre();
            AdjustCurrentGamePlatforms();
        }
    }
}
