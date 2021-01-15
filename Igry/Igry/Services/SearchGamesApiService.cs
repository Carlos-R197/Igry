using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Igry.Models;
using Newtonsoft.Json;

namespace Igry.Services
{
    public class SearchGamesApiService
    {
        public async Task<IList<Game>> SearchAsync(string userInput)
        {
            IList<Game> games = null;
            var client = new HttpClient();
            string query = $"https://api.rawg.io/api/games?key=9b88a4289b784c19b41aff2c40764c6a&search={userInput}";
            HttpResponseMessage response = await client.GetAsync(query);
            if (response.IsSuccessStatusCode)
            {
                GamesList gameList = JsonConvert.DeserializeObject<GamesList>(await response.Content.ReadAsStringAsync());
                games = gameList.Games;
            }
            return games;
        }
    }
}
