using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Igry.Models
{
    public class Favorite
    {
        public string UserEmail { get; set; }
        public int GameId { get; set; }

        public Favorite()
        {  }

        public Favorite(string userEmail, int gameId)
        {
            UserEmail = userEmail;
            GameId = gameId;
        }
    }
}
