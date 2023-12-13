using DataAccessLayer.Data;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            // Validation and business logic...
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.Include(u => u.BooksBorrowed).Include(u => u.BooksLent).ToList();
        }

        public User GetUserById(int userId)
        {
            return _context.Users.Include(u => u.BooksBorrowed).Include(u => u.BooksLent).FirstOrDefault(u => u.UserId == userId);
        }

        public bool IsUserExist(User user) 
        {
            var loginUser = _context.Users
                .Where(b => b.Username == user.Username && b.Password == user.Password)
                .ToList()
                .FirstOrDefault();

            return loginUser != null;
        }

        // Add other methods as needed
    }
}
