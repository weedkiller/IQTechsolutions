using Identity.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoldTechInnovation.Web.Datastores
{
    public class GoldTechInnovationDBContext : IdentityDbContext<IdentityUser>
    {
        public GoldTechInnovationDBContext(DbContextOptions<GoldTechInnovationDBContext> options)
            :base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().OwnsOne(c => c.UserInfo);

            builder.Entity<Brand>().HasKey(c => c.Id);
            builder.Entity<Brand>().ToTable("Brands");

            builder.Entity<Product>().HasKey(c => c.Id);
            builder.Entity<Product>().ToTable("Products");

            builder.Entity<Category>().HasKey(c => c.Id);
            builder.Entity<Category>().ToTable("Categories");

            builder.Entity<Category>().HasData(new Category { Id = "1", Name = "GPU" });
            builder.Entity<Category>().HasData(new Category { Id = "2", Name = "CPU" });
            builder.Entity<Category>().HasData(new Category { Id = "3", Name = "Motherboard" });

            builder.Entity<Product>().HasData(new Product
            {
                Id = "1",
                Name = "Nvidia",
                Price = 5.95M,
                CategoryId = "1",
                ImageUrl = "\\Images\\GPU1.jpg"
            });

            builder.Entity<Product>().HasData(new Product
            {
                Id = "2",
                Name = "Nvidia",
                Price = 50.95M,
                CategoryId = "1",
                ImageUrl = "\\Images\\GPU2.jpg"
            });

            builder.Entity<Product>().HasData(new Product
            {
                Id = "3",
                Name = "Nvidia",
                Price = 500.95M,
                CategoryId = "1",
                ImageUrl = "\\Images\\GPU3.jpg"
            });


            builder.Entity<Product>().HasData(new Product
            {
                Id = "4",
                Name = "Intel",
                Price = 30.95M,
                CategoryId = "2",
                ImageUrl = "\\Images\\CPU1.jpg"

            });

            builder.Entity<Product>().HasData(new Product
            {
                Id = "5",
                Name = "Intel",
                Price = 300.95M,
                CategoryId = "2",
                ImageUrl = "\\Images\\CPU2.jpg"

            });

            builder.Entity<Product>().HasData(new Product
            {
                Id = "6",
                Name = "Intel",
                Price = 3000.95M,
                CategoryId = "2",
                ImageUrl = "\\Images\\CPU3.jpg"

            });


            builder.Entity<Product>().HasData(new Product
            {
                Id = "7",
                Name = "Asus",
                Price = 20.95M,
                CategoryId = "3",
                ImageUrl = "\\Images\\Motherboard1.jpg"
            });

            builder.Entity<Product>().HasData(new Product
            {
                Id = "8",
                Name = "Asus",
                Price = 200.95M,
                CategoryId = "3",
                ImageUrl = "\\Images\\Motherboard2.jpg"
            });

            builder.Entity<Product>().HasData(new Product
            {
                Id = "9",
                Name = "Asus",
                Price = 2000.95M,
                CategoryId = "3",
                ImageUrl = "\\Images\\Motherboard3.jpg"
            });

        }
    }
}
