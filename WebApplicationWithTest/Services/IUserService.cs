using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationWithTest.Dtos;

namespace WebApplicationWithTest.Services
{
    public interface IUserService
    {
        Task<int> CreateUserAsync(CreateUserDto createUserDto);
        Task<UserDto> GetUserByIdAsync(int id);
    }
}
