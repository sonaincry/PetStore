using BusinessObject.Models;
using Microsoft.EntityFrameworkCore; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class UserDAO
    {
        public static UserDAO instance = null;
        private readonly PetStoreContext dbContext;

        public UserDAO()
        {
            dbContext = new PetStoreContext();
        }

        public static UserDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserDAO();
                }
                return instance;
            }
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await dbContext.Users.ToListAsync();
        }

        public async Task<User> AddUserAsync(User user)
        {
            try
            {
                if (dbContext.Users.Any(u => u.Email == user.Email))
                {
                    throw new Exception("A user with this email already exists.");
                }
                await dbContext.Users.AddAsync(user);
                await dbContext.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the user.", ex);
            }
        }

        public async Task<User> UpdateUserAsync(int id, User user)
        {
            try
            {
                var existUser = await dbContext.Users.FirstOrDefaultAsync(u => u.UserId == id);
                if (existUser != null)
                {
                    existUser.FullName = user.FullName ?? existUser.FullName;
                    existUser.Address = user.Address ?? existUser.Address;
                    existUser.Phone = user.Phone ?? existUser.Phone;
                    await dbContext.SaveChangesAsync();
                    return existUser;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the user.", ex);
            }

        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            try
            {
                return await dbContext.Users.FirstOrDefaultAsync(x => x.UserId.Equals(id));
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the user.", ex);
            }
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            try
            {
                return await dbContext.Users.FirstOrDefaultAsync(x => x.UserName.Equals(username) && x.Password.Equals(password));
            }
            
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the user.", ex);
            }
        }
    }
}
