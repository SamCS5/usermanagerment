using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserApplication.Models;

namespace UserApplication.Data
{
    public class UserApplicationContext : DbContext
    {
        public UserApplicationContext(DbContextOptions<UserApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().ToTable("Group");
            modelBuilder.Entity<Permission>().ToTable("Permission");
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
