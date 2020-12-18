using Igry.Models;
using Igry.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Igry.ViewModels
{
    class RandomPlatformViewModel : BaseViewModel
    {
        public ICommand GetRandomPlatformCommand => new Command(GetRandomPlatform);
        public ICommand TapCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
        public PlatformData Platform
        { get; set; }

        async void GetRandomPlatform()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                IGameRandomizerApiService apiService = new GameRandomizerApiService();
                Platform = await apiService.GetRandomPlatformAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Check your internet connection and try again", "Ok");
            }
        }
    }
}
