using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    using System;
    using System.Linq;
    using DataAccessLayer.Data;
    using DataAccessLayer.Models;
    using Microsoft.EntityFrameworkCore;

    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddBook(Book book)
        {
            // Validation and business logic...
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public IEnumerable<Book> GetAvailableBooks()
        {
            return _context.Books.Where(b => b.IsBookAvailable).ToList();
        }

        public void BorrowBook(int bookId, int userId)
        {
            var book = _context.Books.Find(bookId);
            var user = _context.Users.Find(userId);

            if (book == null || user == null)
            {
                throw new ArgumentException("Invalid book or user ID");
            }

            if (!book.IsBookAvailable || user.TokensAvailable < 1)
            {
                throw new InvalidOperationException("Book not available or insufficient tokens");
            }

            // Update book and user properties
            book.IsBookAvailable = false;
            book.CurrentlyBorrowedById = userId;

            user.TokensAvailable--;
            user.BooksBorrowed.Add(book);

            _context.SaveChanges();
        }

        public Book GetBookDetails(int bookId)
        {
            var book = _context.Books.Find(bookId);
            return book;
        }
        // Add other methods as needed
    }

}
