using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Igry.Models;
using Igry.Services;

namespace Igry.ViewModels
{
    public class GameDetailViewModel : BaseViewModel
    {
        IGameRandomizerApiService apiService;

        public DelegateCommand GetRandomGameCommand { get; set; }
        public Game CurrentGame { get; set; }

        public GameDetailViewModel(IGameRandomizerApiService apiService)
        {
            this.apiService = apiService;
            GetRandomGameCommand = new DelegateCommand(GetRandomGame);
        }


        async void GetRandomGame()
        {
            CurrentGame = await apiService.GetRandomAsync();
        }
    }
}
