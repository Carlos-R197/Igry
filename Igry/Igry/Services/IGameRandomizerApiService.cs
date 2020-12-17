using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Igry.Models;

namespace Igry.Services
{
    public interface IGameRandomizerApiService
    {
        Task<Game> GetRandomAsync();
    }
}
