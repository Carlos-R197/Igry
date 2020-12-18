using Igry.ViewModels;
using Prism.Navigation;
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
        public INavigationService navigationService;
        public ICommand RandomPlatformCommand => new Command(RandomPlatform);

        public SettingsViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
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
