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
    public class ETicaretDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var hasher = new PasswordHasher<IdentityUser<int>>();

            builder.Entity<IdentityUser<int>>()
                   .HasData(new IdentityUser<int>
                   {
                       Id = 1,
                       UserName = "admin",
                       NormalizedUserName = "ADMIN",
                       Email = "admin@mail.com",
                       NormalizedEmail = "ADMIN@MAIL.COM",
                       EmailConfirmed = true,
                       PhoneNumberConfirmed = true,
                       PhoneNumber = "-",
                       PasswordHash = hasher.HashPassword(null, "Az*123456"),
                       SecurityStamp = Guid.NewGuid().ToString()
                   });

        }
    }
}
