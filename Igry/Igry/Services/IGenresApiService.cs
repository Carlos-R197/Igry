﻿using Igry.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Igry.Services
{
    public interface IGenresApiService
    {
        Task<IList<Genre>> GetGenres();
    }
}
