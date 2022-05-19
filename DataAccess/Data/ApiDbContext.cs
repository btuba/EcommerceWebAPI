using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Address> Addresss { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            // Database.EnsureCreated(); 
        }
    }
}
