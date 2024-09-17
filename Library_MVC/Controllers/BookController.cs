using Library_API.Models;
using Library_API.Models.DTOs;
using Library_MVC.Models;
using Library_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Library_MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }
        public async Task<IActionResult> BookIndex()
        {
            List<Book> list = new List<Book>();
            var response = await _service.GetAllBooks<ResponseDto>();
            if(response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<Book>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        public async Task<IActionResult> Details(int id)
        {
            Book book = new Book();
            var response = await _service.GetBookById<ResponseDto>(id);
            if(response != null && response.IsSuccess)
            {
                Book model = JsonConvert.DeserializeObject<Book>(Convert.ToString(response.Result));
                return View(model);
            }
            return View();
        }

        public async Task<IActionResult> BookCreate() // Den här skickar viewn
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookCreate(CreatedAndUpdatedBookDTO model) // det här gör create
        {
            if (ModelState.IsValid)
            {
                var response = await _service.CreateBookAsync<ResponseDto>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> UpdateBook(int bookId) // här är det rätt BookId
        {
            var response = await _service.GetBookById<ResponseDto>(bookId);
            if (response != null && response.IsSuccess)
            {
                Book model = JsonConvert.DeserializeObject<Book>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(Book model) // model.BookId är 0.... det ska det inte va
        {
            if (ModelState.IsValid)
            {
                var response = await _service.UpdateBookAsync<ResponseDto>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> DeleteBook(int id)
        {
            var response = await _service.GetBookById<ResponseDto>(id);
            if (response != null && response.IsSuccess)
            {
                Book model = JsonConvert.DeserializeObject<Book>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound("hittar ej från FÖRSTA delete i BookControllern");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(Book model) // Anas använder ID till CouponDTO. Ska jag använda Book.BookId, eller CreatedAndUpdatedBook.Title? Då får jag kanske göra om fler grejer i programmet.
        {
            //if (ModelState.IsValid)
            //{
            //    var response = await _service.DeleteBookAsync<ResponseDto>(model.BookId);
            //    if (response != null && response.IsSuccess)
            //    {
            //        return RedirectToAction(nameof(BookIndex));
            //    }
            //}

            // ModelState.IsValid spökar så jag tog bort den och nu funkar det.
            var response = await _service.DeleteBookAsync<ResponseDto>(model.BookId);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(BookIndex));
            }
            return NotFound("hittar ej från andra delete i BookControllern");
        }
    }
}
