using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Igry.Models;
using Newtonsoft.Json;

namespace Igry.Services
{
    public class GetGameApiService
    {
        public async Task<Game> GetGameOfTheMonth()
        {
            Game game = null;
            var client = new HttpClient();
            var firstDayMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM-dd");
            var today = DateTime.Now.ToString("yyyy-MM-dd");
            //The query is expected to return the game with the highest metacritic score of the current month.
            string query = $"https://api.rawg.io/api/games?key=9b88a4289b784c19b41aff2c40764c6a&dates={firstDayMonth},{today}&ordering=-metacritic&page_size=1";
            HttpResponseMessage response = await client.GetAsync(query);
            if (response.IsSuccessStatusCode)
            {
                var gamesList = JsonConvert.DeserializeObject<GamesList>(await response.Content.ReadAsStringAsync());
                game = gamesList.Games[0];
            }

            return game;
        }
    }
}
