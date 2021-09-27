using BookYourResidency.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourResidency.Api.Models
{
    public interface IUserServices
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<User> UserWithIdAndPass(string email, string pass);
        Task<User> CreateUser(User user);
        Task<User> DeleteUser(int id);
        Task<User> UpdateUser(User user);
        bool UserExist(User user);
    }
}
