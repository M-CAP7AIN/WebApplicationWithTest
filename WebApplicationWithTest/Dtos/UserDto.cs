using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationWithTest.Models;

namespace WebApplicationWithTest.Dtos
{
    public class UserDto
    {
        public UserDto(User user)
        {
            Name = user.Name;
            Email = user.Email;
        }
        public string Name { get; private set; }
        public string Email { get; private set; }
    }
}
