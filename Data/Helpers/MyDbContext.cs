using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Helpers
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Cart> Cart { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductsInCart> ProductsInCart { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>().ToTable("Cart");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ProductsInCart>().ToTable("ProductsInCart");
        }
    }
}
