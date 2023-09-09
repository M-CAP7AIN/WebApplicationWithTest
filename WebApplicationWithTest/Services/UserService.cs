using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationWithTest.Dtos;
using WebApplicationWithTest.Models;
using WebApplicationWithTest.Repositories;

namespace WebApplicationWithTest.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = new User(createUserDto.Name, createUserDto.Email);
            await _userRepository.AddAsync(user);
            return user.Id;
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user != null ? new UserDto(user) : null;
        }
    }
}
