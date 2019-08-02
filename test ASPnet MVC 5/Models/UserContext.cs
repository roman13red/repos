using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace test_ASPnet_MVC_5.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Page> Pages { get; set; }
     
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasMany(c => c.Pages)
            .WithMany(s => s.Users)
            .Map(t => t.MapLeftKey("PageId")
            .MapRightKey("UserId")
            .ToTable("UserPage"));
    }
    }
}