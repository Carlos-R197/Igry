﻿using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Igry.Models;
using Igry.Services;
using System.Collections.ObjectModel;
using Igry.Constants;
using Prism.Services;

namespace Igry.ViewModels
{
    public class GameDetailViewModel : BaseViewModel, INavigatedAware
    {
        private const string isFavoriteImage = "FilledStar.png";
        private const string isNotFavoriteImage = "EmptyStar.png";

        private readonly GamesByIdApiService gamesByIdApiService;
        private readonly DelegateCommand favoriteCommand;
        private readonly Database database;
        private readonly User currentUser;
        private readonly ObservableCollection<Game> favoriteGames;

        public Game CurrentGame { get; set; }
        public GameDetails CurrentGameDetails { get; set; }
        public string CurrentGameGenres { get; set; }
        public string CurrentGamePlatforms { get; set; }
        public string FavoriteImagePath { get; set; }
        public User CurrentUser => currentUser;

        public DelegateCommand FavoriteCommand => favoriteCommand;

        public GameDetailViewModel(INavigationService navService, IPageDialogService dialogService,
            GamesByIdApiService gamesByIdApiService, Database db, 
            User user, ObservableCollection<Game> favoriteGames) : base(navService, dialogService)
        {
            this.gamesByIdApiService = gamesByIdApiService;
            favoriteCommand = new DelegateCommand(ManageGameFavoriteStatus);
            database = db;
            currentUser = user;
            this.favoriteGames = favoriteGames;
        }

        private async void ManageGameFavoriteStatus()
        {
            var favorite = currentUser.Favorites.FirstOrDefault(t => t.GameId == CurrentGame.Id);
            if (favorite != null)
            {
                currentUser.Favorites.Remove(favorite);
                favoriteGames.Remove(favoriteGames.First(t => t.Id == favorite.GameId));
                await database.RemoveFavoriteAsync(favorite);
                FavoriteImagePath = isNotFavoriteImage;
            }
            else
            {
                var newFavorite = new Favorite(currentUser.Email, CurrentGame.Id);
                currentUser.Favorites.Add(newFavorite);

                //Add game to favoriteGames list
                var gameId = new List<int>();
                gameId.Add(newFavorite.GameId);
                var games = await gamesByIdApiService.GetGamesAsync(gameId);
                favoriteGames.Add(games[0]);

                await database.AddFavoriteAsync(newFavorite);
                FavoriteImagePath = isFavoriteImage;
            }
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(INavigationParameters parameters)
        {
            CurrentGame = parameters.GetValue<Game>("Game");
            CurrentGameDetails = await gamesByIdApiService.GetGameDetailsAsync(CurrentGame.Id);
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
                CurrentGamePlatforms = ErrorMessages.NoDataForGame;
        }


        private void AdjustFavoriteImagePath()
        {
            if (currentUser.Favorites.Any(t => t.GameId == CurrentGame.Id))
                FavoriteImagePath = isFavoriteImage;
            else
                FavoriteImagePath = isNotFavoriteImage;
        }
    }
}
