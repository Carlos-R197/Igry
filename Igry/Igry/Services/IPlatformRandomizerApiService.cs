using Igry.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Prism.Services;

namespace Igry.Services
{
    interface IPlatformRandomizerApiService
    {
        Task<PlatformData> GetRandomPlatformAsync();
    }
}
