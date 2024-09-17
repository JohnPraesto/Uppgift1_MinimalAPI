using Library_API.Models;
using Library_API.Models.DTOs;
using Library_MVC.Models;

namespace Library_MVC.Services
{
    public interface IBookService
    {
        Task<T> GetAllBooks<T>();
        Task<T> GetBookById<T>(int id);
        Task<T> CreateBookAsync<T>(CreatedAndUpdatedBookDTO bookDTO);
        Task<T> UpdateBookAsync<T>(Book book);
        Task<T> DeleteBookAsync<T>(int id);
    }
}
