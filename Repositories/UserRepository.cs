using BusinessObject.Models;
using DataAccessObject;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User> AddUserAsync(User user) => UserDAO.Instance.AddUserAsync(user);
        public Task<User> GetUserByIdAsync(int id) => UserDAO.Instance.GetUserByIdAsync(id);
        public Task<List<User>> GetUsersAsync() => UserDAO.Instance.GetUsersAsync();
        public Task<User> LoginAsync(string username, string password) => UserDAO.Instance.LoginAsync(username, password);
        public Task<User> UpdateUserAsync(int id, User user) => UserDAO.Instance.UpdateUserAsync(id, user);
    }
}
