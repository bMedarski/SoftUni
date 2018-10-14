using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PeakStats.Data;
using PeakStats.Helpers;
using PeakStats.Models;
using SimpleMvc.Data;

namespace PeakStats.Services
{
    public class UsersService
    {
	    private readonly PeakStatsContext db;

	    public UsersService()
	    {
		    this.db = new PeakStatsContext();
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
				    Name = username,
				    Password = HashPassword.GetHashSha256(password),
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
			    .FirstOrDefault(t => t.Name == username && t.Password == HashPassword.GetHashSha256(password));
		    //return this.db
		    //    .Users
		    //    .Any(u => u.Username == username && u.Password == HashPassword.GetHashSha256(password));
		    return user;
	    }

	    public UserViewMode GetByName(string username)
	    {
		    return this.db
			    .Users
			    .Where(u => u.Name == username)
			    .Select(u => new UserViewMode
			    {
				    Id = u.Id,
				    Name = u.Name,
			    })
			    .FirstOrDefault();
	    }
	}
}
