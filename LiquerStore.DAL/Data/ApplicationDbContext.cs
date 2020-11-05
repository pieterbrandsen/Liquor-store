using System;
using System.Collections.Generic;
using System.Text;
using LiquerStore.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LiquerStore.DAL
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // All whiskies
        public DbSet<WhiskyModel> Whiskies { get; set; }

        // Employees
        public DbSet<EmployeeModel> Employees { get; set; }

        // Customers
        public DbSet<CustomerModel> Customers { get; set; }
    }
}
