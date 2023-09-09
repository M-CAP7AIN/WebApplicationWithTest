using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationWithTest.Dtos;

namespace WebApplicationWithTest.Services
{
    public interface IAuthService
    {
        JWTTokens AuthenticateUserAsync(string username, string password);
    }
}
