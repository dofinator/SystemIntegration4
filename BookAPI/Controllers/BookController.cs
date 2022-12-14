using BookAPI.Models;
using BookAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("")]
        public async Task<List<Book>> GetBooks()
        {
            return await _bookService.GetBooks();
        }

        [HttpGet("booksfiltered")]
        public async Task<List<Book>> GetBooksFiltered([FromQuery] BooksFilteredDto booksFilteredDto)
        {
            return await _bookService.GetBooksfiltered(booksFilteredDto.Subject, booksFilteredDto.Budget);
        }

        [HttpPost]
        public async Task<bool> BuyBook(BuyBookDto buyBookDto)
        {
            return await _bookService.BuyBook(buyBookDto);
        }


        [HttpPatch("{bookId}")]
        public async Task<bool> ReturnBook(int bookId)
        {
            return await _bookService.ReturnBook(bookId);
        }
    }

    public class BooksFilteredDto
    {
        public string? Subject { get; set; }
        public double? Budget { get; set; }
    }
}
