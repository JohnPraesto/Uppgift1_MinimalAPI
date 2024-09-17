using Library_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    BookId = 1,
                    Title = "Titel of Book",
                    Author = "Author of Book",
                    Genre = "Genre of Book",
                    IsAvailable = true,
                    Published = DateTime.Now
                },
                new Book()
                {
                    BookId = 2,
                    Title = "Book Title",
                    Author = "Book Author",
                    Genre = "Book Genre",
                    IsAvailable = true,
                    Published = DateTime.Now
                },
                new Book()
                {
                    BookId = 3,
                    Title = "The Titel",
                    Author = "The Author",
                    Genre = "The Genre",
                    IsAvailable = false,
                    Published = DateTime.Now
                });
        }
    }
}
