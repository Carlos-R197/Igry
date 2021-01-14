using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Igry.Models;
using Newtonsoft.Json;

namespace Igry.Services
{
    public class GamesByIdApiService
    {
        public async Task<IList<Game>> GetGamesAsync(List<int> gamesIds)
        {
            IList<Game> games = null;
            var client = new HttpClient();

            string query = "https://api.rawg.io/api/games?key=9b88a4289b784c19b41aff2c40764c6a&ids=";
            foreach (int id in gamesIds)
                query += string.Format("{0},", id);
            query = query.TrimEnd(',');

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
