using Igry.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Igry.Services
{
    interface IGameCatalogApiService
    {
        Task<IList<Game>> GetPageAsync(int page, IList<Genre> genres);
    }
}
