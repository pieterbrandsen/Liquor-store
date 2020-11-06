using System;
using System.Collections.Generic;
using System.Text;
using LiquerStore.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LiquerStore.DAL.Services.DbCommands
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // All whisky storages
        public DbSet<StorageModel> Storages { get; set; }

        // All whiskies
        public DbSet<WhiskyModel> Whiskies { get; set; }


        // Employees
        public DbSet<EmployeeModel> Employees { get; set; }

        // Customers
        public DbSet<CustomerModel> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<StorageModel>()
            //    .HasOne(b => b.Whisky)
            //    .WithOne(i => i.Storages)
            //    .HasForeignKey<WhiskyModel>(b => b.StorageForeignKey);
            var storageEtb = modelBuilder.Entity<StorageModel>();
            var whiskyEtb = modelBuilder.Entity<WhiskyModel>();

            storageEtb.HasOne(c => c.Whisky).WithMany();
            storageEtb.HasIndex(c => c.WhiskyId).IsUnique();

            whiskyEtb.HasOne(d => d.Storages).WithMany();
            whiskyEtb.HasIndex(c => c.StorageId).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
