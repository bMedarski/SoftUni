namespace MeTube.App.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Helpers;
    using Models;
    using SimpleMvc.Data;
    using SimpleMvc.Models;

    public class UsersService
    {
        private readonly MeTubeDbContext db;

        public UsersService()
        {
            this.db = new MeTubeDbContext();
        }

        public bool Create(string username, string password, string email)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            try
            {
                var user = new User
                {
                    Username = username,
                    Password = HashPassword.GetHashSha256(password),
                    Email = email
                };

                this.db.Users.Add(user);
                this.db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public User UserExists(string username, string password)
        {
            User user = null;
            var users = this.db.Users.AsQueryable();

            user = users
                .AsEnumerable()
                .FirstOrDefault(t => t.Username == username && t.Password == HashPassword.GetHashSha256(password));
            //return this.db
            //    .Users
            //    .Any(u => u.Username == username && u.Password == HashPassword.GetHashSha256(password));
            return user;
        }

        public UserViewModel GetByName(string username)
        {
            return this.db
                .Users
                .Where(u => u.Username == username)
                .Select(u => new UserViewModel
                {
                    Id = u.Id,
                    Username = u.Username,
                    Email = u.Email,
                    Tubes = u.Tubes
                })
                .FirstOrDefault();
        }
    }

}

