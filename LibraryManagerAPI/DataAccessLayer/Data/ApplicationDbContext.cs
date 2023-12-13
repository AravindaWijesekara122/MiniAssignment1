using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
            new User
            {
                UserId = 1,
                Name = "User1",
                Username = "user1",
                Password = "password1",
                TokensAvailable = 5,
            },
            new User
            {
                UserId = 2,
                Name = "User2",
                Username = "user2",
                Password = "password2",
                TokensAvailable = 3,
            },
            new User
            {
                UserId = 3,
                Name = "User3",
                Username = "user3",
                Password = "password3",
                TokensAvailable = 2,
            },
            new User
            {
                UserId = 4,
                Name = "User4",
                Username = "user4",
                Password = "password4",
                TokensAvailable = 4,
            }
        );
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
