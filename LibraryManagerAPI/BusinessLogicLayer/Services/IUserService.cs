using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Services
{
    

    public interface IUserService
    {
        void AddUser(User user);
        IEnumerable<User> GetAllUsers();
        User GetUserById(int userId);
        // Add other methods as needed
        bool IsUserExist(User user);
    }

}
