using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Igry.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Igry.Services
{
    public class GameRandomizerApiService : IGameRandomizerApiService
    {
        const int resultsPerPage = 10;
        const int maxPages = 1000;

        public async Task<Game> GetRandomAsync()
        {
            Game game = null;
            var client = new HttpClient();
            var rnd = new Random();

            int randomPage = rnd.Next(1, maxPages + 1);
            string query = $"https://api.rawg.io/api/games?genres=4&key=9b88a4289b784c19b41aff2c40764c6a&page={randomPage}&page_size={resultsPerPage}";
            var response = await client.GetAsync(query);

            if (response.IsSuccessStatusCode)
            {
                GamesList gamesList = JsonConvert.DeserializeObject<GamesList>(await response.Content.ReadAsStringAsync());

                int index = rnd.Next(0, gamesList.Games.Count);
                game = gamesList.Games[index];
            }

            /*
            else
            {
                gamesList = null;
                int amountPages = gamesList.Count / resultsPerPage;
                int randomPage = rnd.Next(1, maxPages + 1);

                string query = $"https://api.rawg.io/api/games?genres=4&key=9b88a4289b784c19b41aff2c40764c6a&page={randomPage}&page_size={resultsPerPage}";
                var response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    gamesList = JsonConvert.DeserializeObject<GamesList>(await response.Content.ReadAsStringAsync());

                    int index = rnd.Next(0, resultsPerPage);
                    game = gamesList.Games[index];
                }
            }
            */

            return game;
        }
    }
}
