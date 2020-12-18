using Igry.Models;
using Igry.Services;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Igry.ViewModels
{
    class RandomPlatformViewModel : BaseViewModel
    {
        IPlatformRandomizerApiService apiService;
        OpenUrlService urlService;

        public DelegateCommand GetRandomPlatformCommand => new DelegateCommand(GetRandomPlatform);
        public DelegateCommand<string> TapCommand => new DelegateCommand<string>(async (url) => await urlService.OpenUrlAsync(url));
        public PlatformData Platform { get; set; }

        public RandomPlatformViewModel(IPlatformRandomizerApiService platformService, OpenUrlService urlService)
        {
            this.apiService = platformService;
            this.urlService = urlService;
        }


        async void GetRandomPlatform()
        {
            Platform = await apiService.GetRandomPlatformAsync();
        }
    }
}
