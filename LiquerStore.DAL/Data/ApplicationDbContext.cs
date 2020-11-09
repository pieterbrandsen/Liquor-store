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
        public DbSet<UserToWhisky> UserToWhiskies { get; set; }

        // Employees
        public DbSet<EmployeeModel> Employees { get; set; }

        // Customers
        public DbSet<CustomerModel> Customers { get; set; }
    }
}
