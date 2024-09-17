using Library_API.Data;
using Library_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_API.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _db;
        public BookRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task CreateBook(Book book)
        {
            _db.Books.AddAsync(book);
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _db.Books.ToListAsync();
        }

        public async Task<Book> GetBook(int id)
        {
            return await _db.Books.FirstOrDefaultAsync(b => b.BookId == id);
        }

        public async Task<Book> GetBook(string bookTitle)
        {
            return await _db.Books.FirstOrDefaultAsync(b => b.Title.ToLower() == bookTitle.ToLower());
        }

        public async Task RemoveBook(Book book)
        {
            _db.Books.Remove(book);
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateBook(Book book)
        {
            _db.Books.Update(book);
        }
    }
}
