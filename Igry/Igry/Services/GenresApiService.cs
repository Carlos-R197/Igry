using Igry.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Igry.Services
{
    class GenresApiService : IGenresApiService
    {
        public async Task<IList<Genre>> GetGenres()
        {
            IList<Genre> genreList = null;
            var client = new HttpClient();


            string query = $"https://api.rawg.io/api/genres?key=9b88a4289b784c19b41aff2c40764c6a";
            var response = await client.GetAsync(query);

            if (response.IsSuccessStatusCode)
            {
                GenreList genresList = JsonConvert.DeserializeObject<GenreList>(await response.Content.ReadAsStringAsync());

                genreList = genresList.Results;
            }
            return genreList;
        }
    }
}
