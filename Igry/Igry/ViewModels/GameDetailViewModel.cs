﻿using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Igry.Models;
using Igry.Services;
using Igry.Objects;

namespace Igry.ViewModels
{
    public class GameDetailViewModel : BaseViewModel, INavigatedAware
    {
        private readonly IGameRandomizerApiService apiService;
        private readonly DelegateCommand favoriteCommand;
        private readonly Database database;
        private readonly User currentUser;

        public Game CurrentGame { get; set; }
        public string CurrentGameGenres { get; set; }
        public string CurrentGamePlatforms { get; set; }
        public string FavoriteImagePath { get; set; }
        public User CurrentUser => currentUser;

        public DelegateCommand FavoriteCommand => favoriteCommand;

        public GameDetailViewModel(IGameRandomizerApiService apiService, Database db, User user)
        {
            this.apiService = apiService;
            favoriteCommand = new DelegateCommand(ManageGameFavoriteStatus);
            database = db;
            currentUser = user;
        }

        private async void ManageGameFavoriteStatus()
        {
            var favorite = currentUser.Favorites.FirstOrDefault(t => t.GameId == CurrentGame.Id);
            if (favorite != null)
            {
                currentUser.Favorites.Remove(favorite);
                await database.RemoveFavoriteAsync(favorite);
                FavoriteImagePath = "EmptyStar.png";
            }
            else
            {
                var newFavorite = new Favorite(currentUser.Email, CurrentGame.Id);
                currentUser.Favorites.Add(newFavorite);
                await database.AddFavoriteAsync(newFavorite);
                FavoriteImagePath = "FilledStar.png";
            }
        }


        private async void GetRandomGame()
        {
            CurrentGame = await apiService.GetRandomAsync();
            AdjustCurrentGameGenre();
            AdjustCurrentGamePlatforms();
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {}

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            var game = parameters.GetValue<Game>("Game");
            CurrentGame = game;
            AdjustCurrentGameGenre();
            AdjustCurrentGamePlatforms();
            AdjustFavoriteImagePath();
        }

        private void AdjustCurrentGameGenre()
        {
            if (CurrentGame.Genres.Count > 0)
            {
                CurrentGameGenres = "Genres: ";
                CurrentGameGenres += CurrentGame.Genres[0].Name;
                for (int i = 1; i < CurrentGame.Genres.Count; i++)
                    CurrentGameGenres += ", " + CurrentGame.Genres[i].Name;
            }
        }

        private void AdjustCurrentGamePlatforms()
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


        private void AdjustFavoriteImagePath()
        {
            if (currentUser.Favorites.Any(t => t.GameId == CurrentGame.Id))
                FavoriteImagePath = "FilledStar.png";
            else
                FavoriteImagePath = "EmptyStar.png";
        }
    }
}
