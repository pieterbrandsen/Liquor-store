﻿using LiquerStore.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquerStore.DAL.Services.DbCommands
{
    public interface IStorage
    {
        StorageModel GetWhiskyById(int? id);
        void AddWhisky(StorageModel StorageModel);
            void UpdateWhiskyByModel(StorageModel StorageModel);
        IList<StorageModel> GetAllWhiskies();
        //int GetAllWhiskieStockById(int? id);
    }
    public class StorageService : IStorage
    {
        private ApplicationDbContext db;

        public StorageService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public StorageModel GetWhiskyById(int? id)
        {
            // Get a whisky based on id
            return db.Storages.FirstOrDefault(r => r.Id == id);
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
            return db.Storages.ToList();
            //return from s in db.Storages
            //orderby s.Whisky.Name
            //select s;
        }

        //public int GetAllWhiskieStockById(int? id)
        //{
        //    var currentStock = from w in db.UserToWhiskies
        //           where w.WhiskyId == id
        //           select w;
        //    return currentStock.Count();
        //}
    }
}