using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Igry.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public ICollection<Favorite> Favorites { get; set; }


        //This constructor is for SQLite
        public User() 
        { }

        public User(string email, string name, string password)
        {
            Email = email;
            Name = name;
            Password = password;
            Favorites = new List<Favorite>();
        }
    }
}
