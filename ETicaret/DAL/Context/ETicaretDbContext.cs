using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class ETicaretDbContext : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        
        public ETicaretDbContext(DbContextOptions<ETicaretDbContext> options) : base(options)
        {

        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductImages> productsImages { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var hasher = new PasswordHasher<AppUser>();

            builder.Entity<AppUser>()
                   .HasData(new AppUser
                   {
                       Id = 1,
                       UserName = "admin",
                       Name = "Admin",
                       Surname ="Admin",
                       NormalizedUserName = "ADMIN",
                       Email = "admin@mail.com",
                       NormalizedEmail = "ADMIN@MAIL.COM",
                       EmailConfirmed = true,
                       PhoneNumberConfirmed = true,
                       PhoneNumber = "-",
                       PasswordHash = hasher.HashPassword(null, "Az*123456"),
                       SecurityStamp = Guid.NewGuid().ToString()
                   });

            //Admin Role Add

            builder.Entity<IdentityRole<int>>()
                   .HasData(new IdentityRole<int>
                   {
                       Id = 1,
                       Name = "Admin",
                       NormalizedName = "ADMIN"
                   });

            builder.Entity<IdentityRole<int>>()
                  .HasData(new IdentityRole<int>
                  {
                      Id = 2,
                      Name = "User",
                      NormalizedName = "USER"
                  });

            //User To Role Add

            builder.Entity<IdentityUserRole<int>>()
                   .HasData(new IdentityUserRole<int>
                   {
                       UserId = 1,
                       RoleId = 1
                   });

        }
    }
}
