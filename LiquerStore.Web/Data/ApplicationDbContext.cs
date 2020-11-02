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
        DbSet<WhiskyModel> whiskies { get; set; }

        // Employees
        DbSet<EmployeeModel> employees { get; set; }


        // Customers
        DbSet<CustomerModel> customers { get; set; }
    }
}
