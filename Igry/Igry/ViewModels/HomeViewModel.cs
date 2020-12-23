using System;
using System.Collections.Generic;
using System.Text;

using Igry.Models;
using Igry.Services;
using Prism.Navigation;

namespace Igry.ViewModels
{
    public class HomeViewModel : BaseViewModel, IInitialize
    {
        private readonly GetGameApiService gameApiService;

        public Game GameOfTheWeek { get; private set; }
        
        public HomeViewModel(GetGameApiService getGameApiService)
        {
            this.gameApiService = getGameApiService;
        }

        public async void Initialize(INavigationParameters parameters)
        {
            GameOfTheWeek = await gameApiService.GetGameOfTheMonth();
        }
    }
}
