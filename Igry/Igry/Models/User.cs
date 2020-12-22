using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Igry.Models
{
    public class User
    {
        [PrimaryKey]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public User() 
        { }

        public User(string email, string name, string password)
        {
            Email = email;
            Name = name;
            Password = password;
        }
    }
}
