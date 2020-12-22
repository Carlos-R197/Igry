using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Igry.Models;
using System.Threading.Tasks;
using System.IO;

namespace Igry.Objects
{
    public class Database
    {
        private readonly SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            if (!File.Exists(dbPath))
                File.Create(dbPath);

            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<User>().Wait();
        }

        public Task<User> GetUserAsync(string email, string password)
        {
            return database.Table<User>().FirstOrDefaultAsync(t => t.Email == email && t.Password == password); 
        }

        public Task SaveUserAsync(User user)
        {
            return database.InsertAsync(user);
        }

        public async Task<bool> IsEmailTaken(string email)
        {
            var user = await database.Table<User>().FirstOrDefaultAsync(t => t.Email == email);
            if (user != null)
                return true;
            else
                return false;
        }
    }
}
