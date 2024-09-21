using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Library_API;
using Library_API.Data;
using Library_API.EndPoints;
using Library_API.Models;
using Library_API.Models.DTOs;
using Library_API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Maps));
builder.Services.AddValidatorsFromAssemblyContaining<Program>(); // Behövs den?
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddCors((setup) => setup.AddPolicy("default",(options) =>
{
    options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("default");

app.UseHttpsRedirection();






//app.MapGet("/api/books", () =>
//{
//    APIResponse response = new APIResponse();
//    response.Result = BookStore.bookList;
//    response.IsSuccess = true;
//    response.StatusCode = System.Net.HttpStatusCode.OK;

//    return Results.Ok(response);
//}).WithName("GetBooks").Produces(200); // Vad gör WithName för skillnad? Vad har vi den till?






//app.MapGet("/api/book/{id:int}", (int id) =>
//{
//    APIResponse response = new APIResponse();
//    response.Result = BookStore.bookList.FirstOrDefault(b => b.BookId == id);
//    response.IsSuccess = true;
//    response.StatusCode = System.Net.HttpStatusCode.OK;

//    return Results.Ok(response);
//}).WithName("GetBook").Produces<Book>(200);






//app.MapPost("/api/book", async (IValidator<CreatedAndUpdatedBookDTO> _validator, IMapper _mapper, CreatedAndUpdatedBookDTO book_C_DTO) =>
//{
//    APIResponse response = new APIResponse() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };
//    ValidationResult validationResult = await _validator.ValidateAsync(book_C_DTO);
//    if (!validationResult.IsValid)
//    {
//        response.ErrorMessages.Add(validationResult.Errors.FirstOrDefault().ToString()); // = new List<string> { "Something wrong in creating book" };
//        return Results.BadRequest(response);
//    }
//    if (BookStore.bookList.FirstOrDefault(b => b.Title.ToLower() == book_C_DTO.Title.ToLower()) != null)
//    {
//        response.ErrorMessages.Add("Book name already exists");
//        return Results.BadRequest(response);
//    }

//    Book book = _mapper.Map<Book>(book_C_DTO);
//    book.BookId = BookStore.bookList.OrderByDescending(b => b.BookId).FirstOrDefault().BookId + 1;
//    BookStore.bookList.Add(book);

//    response.Result = book;
//    response.IsSuccess = true;
//    response.StatusCode = System.Net.HttpStatusCode.Created;

//    return Results.Ok(response); // Vad är det för skillnad på Created och CreatedAtRoute?

//}).WithName("CreateBook").Produces<Book>(201).Accepts<APIResponse>("application/json").Produces(400); // Vad är syftet med att ha med .Produces()? Swagger returnerar ju rätt felkoder ändå? Vad använder vi Accepts till? "api-dokumentation"






//app.MapPut("/api/book", async (/*IMapper _mapper, */IValidator<Book> _validator, Book bookToUpdate, int id) =>
//{
//    APIResponse response = new APIResponse() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };
//    var book = BookStore.bookList.FirstOrDefault(b => b.BookId == id);
//    if (book is null)
//        return Results.NotFound($"Bok med id {id} finns inte i databasen");

//    var validationResult = await _validator.ValidateAsync(bookToUpdate);
//    if (!validationResult.IsValid)
//    {
//        response.ErrorMessages.Add(validationResult.Errors.FirstOrDefault().ToString());
//        return Results.BadRequest("Invalid Title (or Author?)");
//    }

//    book.Author = bookToUpdate.Author;
//    book.Title = bookToUpdate.Title;
//    book.Genre = bookToUpdate.Genre;
//    book.Published = bookToUpdate.Published;
//    book.IsAvailable = bookToUpdate.IsAvailable;

//    response.Result = book;
//    response.IsSuccess = true;
//    response.StatusCode = System.Net.HttpStatusCode.OK;

//    return Results.Ok(response);
//}).WithName("UpdateBook").Accepts<Book>("application/json").Produces<Book>(200).Produces(400);






//app.MapDelete("/api/book/{id:int}", (int id) =>
//{
//    APIResponse response = new APIResponse() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };
//    Book book = BookStore.bookList.FirstOrDefault(b => b.BookId == id);
//    if(book != null)
//    {
//        BookStore.bookList.Remove(book);
//        response.IsSuccess = true;
//        response.StatusCode = System.Net.HttpStatusCode.NoContent;
//        return Results.Ok(response);
//    }
//    else
//    {
//        //response.ErrorMessages.Add("Invalid Id");
//        //return Results.BadRequest(response);
//        return Results.BadRequest("Invalid Id");
//    }
//});
app.ConfigurationBookEndPoints();
app.Run();