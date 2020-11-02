using System;
using System.Collections.Generic;
using System.Text;
using LiquorStore.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LiquerStore.Web.Data
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
