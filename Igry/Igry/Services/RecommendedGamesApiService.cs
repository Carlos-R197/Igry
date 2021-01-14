using Igry.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Igry.Services
{
    public class RecommendedGamesApiService
    {
        public async Task<IList<Game>> GetDefaultGamesAsync()
        {
            IList<Game> games = null;
            var client = new HttpClient();
            var firstDay = DateTime.Today.AddDays(-365).ToString("yyyy-MM-dd");
            var lastDay = DateTime.Today.ToString("yyyy-MM-dd");
            string query = $"https://api.rawg.io/api/games?key=9b88a4289b784c19b41aff2c40764c6a&page_size=20&ordering=metacritic&dates={firstDay},{lastDay}";
            HttpResponseMessage response = await client.GetAsync(query);
            if (response.IsSuccessStatusCode)
            {
                GamesList gamesList = JsonConvert.DeserializeObject<GamesList>(await response.Content.ReadAsStringAsync());
                games = gamesList.Games;
            }
            return games;
        }
    }
}
