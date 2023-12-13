using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public interface IBookService
    {
        void AddBook(Book book);
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Book> GetAvailableBooks();
        void BorrowBook(int bookId, int userId);
        Book GetBookDetails(int bookId);

        // Add other methods as needed
    }
}
