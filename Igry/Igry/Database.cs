using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Igry.Models;
using System.Threading.Tasks;
using System.IO;

namespace Igry
{
    public class Database
    {
        private readonly SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            if (!File.Exists(dbPath))
            {
                File.Create(dbPath);
                database = new SQLiteAsyncConnection(dbPath);
                database.ExecuteAsync("CREATE TABLE User (Email nvarchar(50) PRIMARY KEY, Name nvarchar(50), Password nvarchar(50));").Wait();
                database.ExecuteAsync("CREATE TABLE Favorite (UserEmail nvarchar(50), GameId int, FOREIGN KEY (UserEmail) REFERENCES User(Email));").Wait();
            }
            else
               database = new SQLiteAsyncConnection(dbPath);

        }

        public async Task<User> GetUserAsync(string email, string password)
        {
            List<User> users = await database.QueryAsync<User>($"SELECT * FROM User WHERE \'{email}\' == Email");
            if (users.Count > 0)
            {
                users[0].Favorites = await database.QueryAsync<Favorite>($"SELECT * FROM Favorite WHERE \'{email}\' == UserEmail");
                return users[0];
            }
            else
                return null;
        }

        public Task SaveUserAsync(User user)
        {
            return database.ExecuteAsync($"INSERT INTO User (Email, Name, Password) VALUES (\'{user.Email}\', \'{user.Name}\', \'{user.Password}\');");
        }

        public async Task<bool> IsEmailTaken(string email)
        {
            var user = await database.Table<User>().FirstOrDefaultAsync(t => t.Email == email);
            return user != null;
        }

        public Task AddFavoriteAsync(Favorite favorite)
        {
            return database.ExecuteAsync($"INSERT INTO Favorite (UserEmail, GameId) VALUES (\'{favorite.UserEmail}\', \'{favorite.GameId}\');");
        }

        public Task RemoveFavoriteAsync(Favorite favorite)
        {
            return database.ExecuteAsync($"DELETE FROM Favorite WHERE UserEmail == \'{favorite.UserEmail}\'");
        }
    }
}
