using Igry.ViewModels;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Igry.Views
{
    class SettingsViewModel : BaseViewModel
    {
        public ICommand GameDetailCommand => new Command(GameDetail);
        public ICommand RandomPlatformCommand => new Command(RandomPlatform);

        public SettingsViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService, dialogService)
        {
        }

        private async void GameDetail()
        {
            await navigationService.NavigateAsync("NavigationPage/GameDetailPage");
        }
        private async void RandomPlatform()
        {
            await navigationService.NavigateAsync("NavigationPage/RandomPlatformPage");
        }
    }
}
