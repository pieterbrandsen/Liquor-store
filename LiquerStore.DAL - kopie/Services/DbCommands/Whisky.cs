using LiquerStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using LiquerStore.Web.Data;

namespace LiquerStore.DAL.Services.DbCommands
{
    class Whisky
    {
        public interface IWhisky
        {
            WhiskyModel GetWhiskyById(int id);
        }

        public class WhiskyService : IWhisky
        {
            ApplicationDbContext db;

            public WhiskyService(ApplicationDbContext db)
            {
                this.db = db;
            }
        }
    }
}
