using Microsoft.EntityFrameworkCore;
using ShopApp.Models;

namespace ShopApp.Data {
    public class ApplicationDbContext :DbContext{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base( options ) {

        }
        // creating table
        public DbSet<Company> Companies {
            get; set;
        }
        public DbSet<Product> products {
            get; set;
        }
        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1 , Name = "Niki"},
                new Company { Id = 2 , Name = "Adidas"}
                );
        }
        
    }
}
