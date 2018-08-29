using BilisimKreatif.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BilisimKreatif.Data
{

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<BilisimKreatif.Model.Customer> Customers { get; set; }
        public DbSet<BilisimKreatif.Model.Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new Maps.CustomerMap(modelBuilder.Entity<Customer>());
            new Maps.ProductMap(modelBuilder.Entity<Product>());
        }
    }

}
