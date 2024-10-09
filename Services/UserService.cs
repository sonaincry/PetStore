using AutoMapper;
using BusinessObject.Models;
using BusinessObject.Models.DTO;
using Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<User> AddUserAsync(UserCreateDTO userCreateDTO)
        {
            var user = _mapper.Map<User>(userCreateDTO);
            return await _repository.AddUserAsync(user);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _repository.GetUserByIdAsync(id);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _repository.GetUsersAsync();
        }

        public async Task<User> LoginAsync(UserLoginDTO userLoginDTO)
        {
            var user = _mapper.Map<User>(userLoginDTO);
            return await _repository.LoginAsync(user.UserName, userLoginDTO.Password);
        }

        public async Task<User> UpdateUserAsync(int id, UserUpdateDTO userUpdateDTO)
        {
            var existingUser = await _repository.GetUserByIdAsync(id);
            if (existingUser == null)
            {
                return null;
            }

            existingUser.FullName = userUpdateDTO.FullName ?? existingUser.FullName;
            existingUser.Address = userUpdateDTO.Address ?? existingUser.Address;
            existingUser.Phone = userUpdateDTO.Phone ?? existingUser.Phone;

            return await _repository.UpdateUserAsync(id, existingUser);
        }
    }
}
