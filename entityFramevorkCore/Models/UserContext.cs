using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace entityFramevorkCore.Models
{
    public class UserContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Page> Pages { get; set; }
        public UserContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPage>()
            .HasKey(t => new { t.UserId, t.PageId });

            modelBuilder.Entity<UserPage>()
                .HasOne(sc => sc.User)
                .WithMany(s => s.Pages)
                .HasForeignKey(sc => sc.UserId);

            modelBuilder.Entity<UserPage>()
                .HasOne(sc => sc.Page)
                .WithMany(c => c.Users)
                .HasForeignKey(sc => sc.PageId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=User1 ;Username=postgres;Password=246101626ROMANkutkin");
        }
    }
}
