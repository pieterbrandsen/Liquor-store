using LiquerStore.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquerStore.DAL.Services.DbCommands
{
    public interface IUserToWhisky
    {
    }
    public class UserToWhiskyService : IUserToWhisky
    {
        private ApplicationDbContext db;

        public UserToWhiskyService(ApplicationDbContext db)
        {
            this.db = db;
        }
    }
}
