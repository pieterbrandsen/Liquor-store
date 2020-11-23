using LiquerStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiquerStore.DAL.Services.DbCommands
{
    public interface IUser
    {
        ApplicationUser GetUserById(string? id);
        ApplicationUser GetUserByName(string? name);

        IList<ApplicationUser> GetAllUsers();
    }

    public class UserService : IUser
    {
        // Get the db context
        private readonly ApplicationDbContext db;

        public UserService(ApplicationDbContext db)
        {
            // Set the saved db context to this db context
            this.db = db;
        }

        public IList<ApplicationUser> GetAllUsers()
        {
            return db.Users.ToList();
        }

        public ApplicationUser GetUserById(string? id)
        {
            return db.Users.FirstOrDefault(r => r.Id == id);
        }

        public ApplicationUser GetUserByName(string? name)
        {
            return db.Users.FirstOrDefault(r => r.UserName == name);
        }
    }
}
