using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Igry.Services
{
    public class OpenUrlService
    {
        public async Task OpenUrlAsync(string url)
        {
            await Launcher.OpenAsync(url);
        }
    }
}
