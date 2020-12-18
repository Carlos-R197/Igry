﻿using Igry.ViewModels;
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
        public INavigationService _navigationService;
        public ICommand RandomPlatformCommand => new Command(RandomPlatform);

        public SettingsViewModel(INavigationService navigationService)
        {

            _navigationService = navigationService;
        }

        private async void GameDetail()
        {
            await _navigationService.NavigateAsync("GameDetailPage");
        }
        private async void RandomPlatform()
        {
            await _navigationService.NavigateAsync("RandomPlatformPage");
        }
    }
}