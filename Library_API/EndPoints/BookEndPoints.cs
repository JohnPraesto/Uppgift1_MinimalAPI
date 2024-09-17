using AutoMapper;
using Library_API.Data;
using Library_API.Models;
using Library_API.Models.DTOs;
using Library_API.Repositories;
using static Azure.Core.HttpHeader;

namespace Library_API.EndPoints
{
    public static class BookEndPoints
    {
        public static void ConfigurationBookEndPoints(this WebApplication app)
        {
            app.MapGet("/api/books", GetAllBooks).WithName("GetBooks").Produces<APIResponse>();
            app.MapGet("/api/book/{id:int}", GetBook).WithName("GetBook").Produces<APIResponse>();
            app.MapPost("/api/book", CreateBook).WithName("CreateBook").Accepts<CreatedAndUpdatedBookDTO>("application/json").Produces(400);
            app.MapPut("/api/book", UpdateBook).WithName("UpdateBook").Accepts<Book>("application/json").Produces<Book>(200).Produces(400);
            app.MapDelete("/api/book/{id:int}", DeleteBook).WithName("DeleteBook");
        }
        private async static Task<IResult> GetAllBooks(IBookRepository _repo)
        {
            APIResponse response = new APIResponse();
            response.Result = await _repo.GetAllBooks();
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;

            return Results.Ok(response);
        }

        private async static Task<IResult> GetBook(IBookRepository _repo, int id)
        {
            APIResponse response = new APIResponse();
            response.Result = await _repo.GetBook(id);
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;

            return Results.Ok(response);
        }

        private async static Task<IResult> CreateBook(IBookRepository _repo, IMapper _mapper, CreatedAndUpdatedBookDTO book_C_DTO)
        {
            APIResponse response = new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };
            if(_repo.GetBook(book_C_DTO.Title).GetAwaiter().GetResult() != null)
            {
                response.ErrorMessages.Add("Boken är redan registrerad");
                return Results.BadRequest(response);
            }

            Book book = _mapper.Map<Book>(book_C_DTO);
            await _repo.CreateBook(book);
            await _repo.Save();
            CreatedAndUpdatedBookDTO bookDTO = _mapper.Map<CreatedAndUpdatedBookDTO>(book);

            response.Result = bookDTO;
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.Created;

            return Results.Ok(response);
        }


        private async static Task<IResult> UpdateBook(IBookRepository _repo, IMapper _mapper, Book bookToUpdate)
        {
            APIResponse response = new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

            await _repo.UpdateBook(_mapper.Map<Book>(bookToUpdate));
            await _repo.Save();

            response.Result = _mapper.Map<Book>(await _repo.GetBook(bookToUpdate.BookId)); // ändrat till Book från Createdewefoisn
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return Results.Ok(response);
        }

        private async static Task<IResult> DeleteBook(IBookRepository _repo, int id)
        {
            APIResponse response = new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

            Book bookFromDb = await _repo.GetBook(id);

            if (bookFromDb != null)
            {
                await _repo.RemoveBook(bookFromDb);
                await _repo.Save();
                response.IsSuccess = true;
                response.StatusCode = System.Net.HttpStatusCode.NoContent;
                return Results.Ok(response);
            }
            else
            {
                response.ErrorMessages.Add("Invalid ID");
                return Results.BadRequest(response);
            }

        }
    }
}
