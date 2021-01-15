using Igry.ViewModels;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Igry.Constants;
using System.Collections.ObjectModel;
using Igry.Models;
using Igry.Services;

namespace Igry.ViewModels
{
    class SettingsViewModel : BaseViewModel
    {
        private readonly OpenUrlService openUrlService;

        private ObservableCollection<Game> favoriteGames;

        public DelegateCommand LogOutCommand => new DelegateCommand(LogOut);
        public DelegateCommand GoToRawgApiCommand => new DelegateCommand(GoToRawgApi);

        public SettingsViewModel(INavigationService navigationService, IPageDialogService dialogService, OpenUrlService urlService,
            ObservableCollection<Game> favoriteGames) : base(navigationService, dialogService)
        {
            openUrlService = urlService;
            this.favoriteGames = favoriteGames;
        }

        private async void GoToRawgApi()
        {
            await openUrlService.OpenUrlAsync("https://rawg.io/apidocs");
        }

        private async void LogOut()
        {
            bool userChoice = await dialogService.DisplayAlertAsync(Titles.Important,
                SuccessMessages.LogOut, AlertButtonMessages.Accept, AlertButtonMessages.Cancel);

            if (userChoice == true)
            {
                favoriteGames.Clear();
                await navigationService.NavigateAsync($"/{PageName.NavigationPage}/{PageName.LoginPage}");
            }
        }
    }
}
