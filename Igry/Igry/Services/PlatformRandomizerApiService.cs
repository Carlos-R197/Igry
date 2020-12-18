using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Igry.Services;
using Igry.Models;
using Xamarin.Essentials;
using Prism.Services;
using System.Net.Http;
using Newtonsoft.Json;

namespace Igry.Services
{
    public class PlatformRandomizerApiService : IPlatformRandomizerApiService
    {
        IPageDialogService dialogService;

        public PlatformRandomizerApiService(IPageDialogService dialogService)
        {
            this.dialogService = dialogService;
        }

        public async Task<PlatformData> GetRandomPlatformAsync()
        {
            PlatformData platform = null;

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var client = new HttpClient();
                var rnd = new Random();

                var response = await client.GetAsync("https://api.rawg.io/api/platforms?key=7b8dd461e6ef42df8e64b4964852ce00");

                if (response.IsSuccessStatusCode)
                {
                    var platformList = JsonConvert.DeserializeObject<PlatformList>(await response.Content.ReadAsStringAsync());

                    int rand = rnd.Next(0, platformList.Count);
                    platform = platformList.Results[rand];
                }
            }
            else
                await dialogService.DisplayAlertAsync("Error", "Check your internet connection and try again", "Ok");

            return platform;
        }
    }
}
