using LiquerStore.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquerStore.DAL.Services.DbCommands
{
    public interface IWhisky
    {
        WhiskyModel GetWhiskyById(int? id);
        void AddWhisky(WhiskyModel whiskyModel);
            void UpdateWhiskyByModel(WhiskyModel whiskyModel);
        IList<WhiskyModel> GetAllWhiskies();
        int GetAllWhiskieStockById(int? id);
    }
    public class WhiskyService : IWhisky
    {
        private ApplicationDbContext db;

        public WhiskyService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public WhiskyModel GetWhiskyById(int? id)
        {
            // Get a whisky based on id
            return db.Whiskies.FirstOrDefault(r => r.Id == id);
        }

        public void AddWhisky(WhiskyModel whiskyModel)
        {
            // Add a whisky to the db
            db.Whiskies.Add(whiskyModel);
            db.SaveChanges();
        }

        public void UpdateWhiskyByModel(WhiskyModel whiskyModel)
        {
            db.Attach(whiskyModel).State = EntityState.Modified;
            db.Whiskies.Update(whiskyModel);

                db.SaveChangesAsync();
        }

        public IList<WhiskyModel> GetAllWhiskies()
        {
            return db.Whiskies.ToList();
        }

        public int GetAllWhiskieStockById(int? id)
        {
            var currentStock = from w in db.UserToWhiskies
                   where w.WhiskyId == id
                   select w;
            return currentStock.Count();
        }
    }
}
