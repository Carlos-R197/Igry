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
        public IList<Genre> loadedGenres = null;
        public string Append;
        public async Task<IList<Game>> GetPageAsync(int page, IList<Genre> genres)
        {
            IList<Game> game = null;
            var client = new HttpClient();
            int pageSize = 20;
            string query = $"https://api.rawg.io/api/games?key=9b88a4289b784c19b41aff2c40764c6a&page={page}&page_size={pageSize}";

            if (genres != null)
            {
                loadedGenres = genres;
                string Append = null;
                for (int i = 0; i < loadedGenres.Count; i++)
                {
                    if (i == 0)
                    {
                        Append += "&genres=" + loadedGenres[i].Id;
                    }
                    else Append += "," + loadedGenres[i].Id;
                }
                query += Append;
            }
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
