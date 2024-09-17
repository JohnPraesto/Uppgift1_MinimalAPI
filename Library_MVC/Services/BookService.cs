using Library_API.Models;
using Library_API.Models.DTOs;

namespace Library_MVC.Services
{
    public class BookService : BaseService, IBookService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<T> CreateBookAsync<T>(CreatedAndUpdatedBookDTO bookDTO)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                Type = StaticDetails.ApiType.POST,
                Data = bookDTO,
                Url = StaticDetails.BookApiBase + "/api/book",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteBookAsync<T>(int id)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                Type = StaticDetails.ApiType.DELETE,
                Url = StaticDetails.BookApiBase + "/api/book/" + id,
                AccessToken = ""
            });
        }

        public Task<T> GetAllBooks<T>()
        {
            return this.SendAsync<T>(new Models.ApiRequest()
            {
                Type = StaticDetails.ApiType.GET,
                Url = StaticDetails.BookApiBase + "/api/books",
                AccessToken = ""
            });
        }

        public async Task<T> GetBookById<T>(int id)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                Type = StaticDetails.ApiType.GET,
                Url = StaticDetails.BookApiBase + "/api/book/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateBookAsync<T>(Book bookDTO)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                Type = StaticDetails.ApiType.PUT,
                Data = bookDTO,
                Url = StaticDetails.BookApiBase + "/api/book",
                AccessToken = ""
            });
        }
    }
}
