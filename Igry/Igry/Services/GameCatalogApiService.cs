using Igry.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Igry.Services
{
    class GameCatalogApiService : IGameCatalogApiService
    {
        public async Task<IList<Game>> GetPageAsync(int page)
        {
            IList<Game> game = null;
            var client = new HttpClient();
            int pageSize = 20;
            
            string query = $"https://api.rawg.io/api/games?key=9b88a4289b784c19b41aff2c40764c6a&page={page}&page_size={pageSize}";
            var response = await client.GetAsync(query);

            if (response.IsSuccessStatusCode)
            {
                GamesList gamesList = JsonConvert.DeserializeObject<GamesList>(await response.Content.ReadAsStringAsync());

                game = gamesList.Games;
            }

            return game;
        }
    }
}
