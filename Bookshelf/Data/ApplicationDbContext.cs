using System;
using System.Collections.Generic;
using System.Text;
using Bookshelf.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bookshelf.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Admina",
                LastName = "Straytor",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            builder.Entity<ApplicationUser>().HasData(user);

            Author author = new Author
            {
                FirstName = "Stephen",
                LastName = "King",
                Id = 1,
                PreferredGenre = "Horror",
                ApplicationUserId = user.Id
            };

            builder.Entity<Author>().HasData(author);

            Book book = new Book
            {
                ISBN = "98765432100",
                Title = "The Shining",
                PublishedDate = new DateTime(1977, 5, 4),
                ApplicationUserId = user.Id,
                AuthorId = author.Id,
                Genre = "Horror",
                Id = 1
            };

            builder.Entity<Book>().HasData(book);
        }
    }
}
