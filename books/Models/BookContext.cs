using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace books.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
      
        public BookContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Book[] c = new Book[1000];
            //for (int x = 0; x <= 100; x++)
            //{
            //     c[x] = new Book { Id = x+1000, NameBook = $"Test+{x}", Blook = 'a', Date = new DateTime(2013, 1, 1), Count = x, Ok = true, Price = x };
            //}

            //    modelBuilder.Entity<Book>().HasData(c);


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=Books ;Username=postgres;Password=246101626ROMANkutkin");
        }
       
    }
}
