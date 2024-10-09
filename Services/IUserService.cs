using BusinessObject.Models;
using BusinessObject.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        Task<User> AddUserAsync(UserCreateDTO userCreateDTO);
        Task<User> UpdateUserAsync(int id, UserUpdateDTO userUpdateDTO);
        Task<User> GetUserByIdAsync(int id);
        Task<User> LoginAsync(UserLoginDTO userLoginDTO);
    }
}
