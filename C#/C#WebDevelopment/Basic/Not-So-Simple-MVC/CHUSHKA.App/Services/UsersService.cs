using System;
using System.Linq;
using CHUSHKA.App.ViewModels;
using CHUSHKA.Data;
using CHUSKA.Models;
using SoftUni.WebServer.Common;
using SoftUni.WebServer.Mvc.Security;

namespace CHUSHKA.App.Services
{
    public class UsersService
    {
	    private readonly ChuskaContex db;

	    public UsersService()
	    {
		    this.db = new ChuskaContex();
	    }

	    public bool Create(string username, string password, string email,string fullName = "")
	    {
		    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
		    {
			    return false;
		    }

		    try
		    {

			    var role = this.db.Roles.Find(2);

			    var user = new User
			    {
				    Username = username,
				    Password = PasswordUtilities.GetPasswordHash(password),
				    Email = email,
					FullName = fullName,
					Role = role
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
			    .FirstOrDefault(t => t.Username == username && t.Password == PasswordUtilities.GetPasswordHash(password));

		    //if (user.Role.Id == 1)
		    //{

			   // var currentUser = new Authentication(user.Id,user.Username,);
		    //}		    //if (user.Role.Id == 1)
		    //{

			   // var currentUser = new Authentication(user.Id,user.Username,);
		    //}

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
					FullName = u.FullName
				    
			    })
			    .FirstOrDefault();
	    }
	}
}
