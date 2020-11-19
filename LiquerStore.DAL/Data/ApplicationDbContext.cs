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

        // All whisky including additional parts like count
        public DbSet<StorageModel> Storages { get; set; }

        // All whiskies types
        public DbSet<WhiskyModel> Whiskies { get; set; }


        // Employees
        public DbSet<EmployeeModel> Employees { get; set; }

        // Customers
        public DbSet<UserModels> Customers { get; set; }
    }
}