using System.Collections.Generic;
using System.Linq;
using LiquerStore.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace LiquerStore.DAL.Services.DbCommands
{
    public interface IStorage
    {
        // Find a whisky from the Storage table with the id inputted
        StorageModel GetWhiskyById(int? id);
        // Add a storageModel to the Storage table
        void AddWhisky(StorageModel StorageModel);
        // Update a row from the Storage table
        void UpdateWhiskyByModel(StorageModel StorageModel);

        // Get all Whiskies from the storage table
        IList<StorageModel> GetAllWhiskies();
        // Get all Whiskies that are not soft deleted and have more then 0 availiable
        IList<StorageModel> GetAllActiveWhiskies();
    }

    public class StorageService : IStorage
    {
        // Get the db context
        private readonly ApplicationDbContext db;

        public StorageService(ApplicationDbContext db)
        {
            // Set the saved db context to this db context
            this.db = db;
        }

        public StorageModel GetWhiskyById(int? id)
        {
            // Get a whisky based on id
            var test = db.Storages.Include(s => s.Whisky).FirstOrDefault(r => r.Id == id);
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
            // Update a whisky based on StorageModel
            db.Attach(storageModel).State = EntityState.Modified;
            db.Storages.Update(storageModel);

            db.SaveChanges();
        }

        public IList<StorageModel> GetAllWhiskies()
        {
            // Return all whiskies saved in the storage model
            return db.Storages.Include(s => s.Whisky).ToList();
        }
        public IList<StorageModel> GetAllActiveWhiskies()
        {
            // Return all whiskies that are not soft deleted and have more then 0 available
            return db.Storages.Include(s => s.Whisky).Where(s => s.SoftDeleted == false && s.Available > 0).ToList();
        }
    }
}