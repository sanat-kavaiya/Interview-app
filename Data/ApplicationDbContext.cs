using Microsoft.EntityFrameworkCore;
using myApp.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace myApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee_MDL> EmployeDetail { get; set; }
        public DbSet<Company_MDL> CompanyDetail { get; set; }
        public DbSet<StudentDetails_MDL> StudentDetail { get; set; }
        // Add other DbSets for your models

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships, constraints, etc.
            base.OnModelCreating(modelBuilder);
        }
    }
}
