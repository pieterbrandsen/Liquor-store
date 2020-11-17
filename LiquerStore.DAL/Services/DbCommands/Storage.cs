using System.Collections.Generic;
using System.Linq;
using LiquerStore.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace LiquerStore.DAL.Services.DbCommands
{
    public interface IStorage
    {
        StorageModel GetWhiskyById(int? id);
        void AddWhisky(StorageModel StorageModel);
        void UpdateWhiskyByModel(StorageModel StorageModel);

        IList<StorageModel> GetAllWhiskies();
        IList<StorageModel> GetAllActiveWhiskies();
    }

    public class StorageService : IStorage
    {
        private readonly ApplicationDbContext db;

        public StorageService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public StorageModel GetWhiskyById(int? id)
        {
            // Get a whisky based on id
            return db.Storages.Include(s => s.Whisky).FirstOrDefault(r => r.Id == id);
        }

        public void AddWhisky(StorageModel StorageModel)
        {
            // Add a whisky to the db
            db.Storages.Add(StorageModel);
            db.SaveChanges();
        }

        public void UpdateWhiskyByModel(StorageModel storageModel)
        {
            db.Attach(storageModel).State = EntityState.Modified;
            db.Storages.Update(storageModel);

            db.SaveChanges();
        }

        public IList<StorageModel> GetAllWhiskies()
        {
            return db.Storages.Include(s => s.Whisky).ToList();
            //return from s in db.Storages
            //orderby s.Whisky.Name
            //select s;
        }
        public IList<StorageModel> GetAllActiveWhiskies()
        {
            return db.Storages.Include(s => s.Whisky).Where(s => s.SoftDeleted == false && s.Available > 0).ToList();
        }
    }
}