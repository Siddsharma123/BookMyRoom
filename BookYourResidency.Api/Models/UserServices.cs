using BookYourResidency.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookYourResidency.Api.Models
{
    public class UserServices : IUserServices
    {
        private readonly BookYourResidencyDbContext _context;
        public UserServices(BookYourResidencyDbContext context)
        {
            this._context = context;
        }
        public async Task<User> CreateUser(User user)
        {
            var tempUser = await _context.Users.AnyAsync(b => b.EmailAddress == user.EmailAddress);
            if (tempUser == true)
            {
                throw new Exception("User already Exist With this Email");
            }
            else
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return _context.Users.Single(n => n.EmailAddress == user.EmailAddress);
            }
        }

        public async Task<User> DeleteUser(int id)
        {
            var tempUser = await _context.Users.FindAsync(id);
            if (tempUser == null)
            {
                throw new Exception("User already Exist With this Email");
            }
            else
            {
                _context.Users.Remove(tempUser);
                await _context.SaveChangesAsync();
                return tempUser;
            }
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(e => e.UserId == id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.Include(e => e.Properties).ToListAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            var result = await _context.Users.FirstOrDefaultAsync(e => e.UserId == user.UserId);
            if (result != null)
            {
                result.FirstName = user.FirstName;
                result.LastName = user.LastName;
                result.Password = user.Password;
                if (result.EmailAddress != user.EmailAddress)
                {
                    var flag = _context.Users.Any(e => e.EmailAddress == user.EmailAddress);
                    if (flag == true)
                    {
                        throw new Exception("Email already exists");
                    }
                    else
                    {
                        result.EmailAddress = user.EmailAddress;
                    }
                }
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public bool UserExist(User user)
        {
            var idcheck = _context.Users.Any(e => e.UserId == user.UserId);
            var mailcheck = _context.Users.Any(e => e.EmailAddress == user.EmailAddress);
            if (idcheck || mailcheck)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<User> UserWithIdAndPass(string email, string pass)
        {
            var result = await _context.Users.FirstOrDefaultAsync(e => e.EmailAddress == email);
            if (result != null && result.Password == pass)
            {
                return result;
            }
            return null;
        }
    }
}
