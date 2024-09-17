using Library_API.Models;

namespace Library_API.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBook(int id);
        Task<Book> GetBook(string bookTitle);
        Task CreateBook(Book book);
        Task UpdateBook(Book book);
        Task RemoveBook(Book book);
        Task Save();
    }
}
