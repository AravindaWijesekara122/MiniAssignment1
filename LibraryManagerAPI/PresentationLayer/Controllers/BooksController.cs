using BusinessLogicLayer.Services;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpPost("add")]
        public IActionResult AddBook(Book book)
        {
            try
            {
                _bookService.AddBook(book);
                return Ok("Book added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var allBooks = _bookService.GetAllBooks();
                return Ok(allBooks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("available")]
        public IActionResult GetAvailableBooks()
        {
            var availableBooks = _bookService.GetAvailableBooks();
            return Ok(availableBooks);
        }

        [HttpPost("borrow/{bookId}/{userId}")]
        public IActionResult BorrowBook(int bookId, int userId)
        {
            try
            {
                _bookService.BorrowBook(bookId, userId);
                return Ok("Book borrowed successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{bookId}")]
        public IActionResult GetBookDetails(int bookId)
        {
            try
            {
                var bookDetails = _bookService.GetBookDetails(bookId);

                if (bookDetails == null)
                {
                    return NotFound("Book not found");
                }

                return Ok(bookDetails);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            // Add other actions as needed
        }
    }
}
