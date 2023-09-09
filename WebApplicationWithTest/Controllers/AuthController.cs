using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationWithTest.Dtos;
using WebApplicationWithTest.Services;

namespace WebApplicationWithTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var token = _authService.AuthenticateUserAsync(request.Username, request.Password);

            if (token == null)
            {
                return Unauthorized(); // Authentication failed
            }

            return Ok(token);
        }

        [HttpGet("Check")]
        public IActionResult Check()
        {
            return Ok(User.Identity.IsAuthenticated);
        }

        [HttpGet("CheckAuth")]
        [Authorize]
        public IActionResult CheckAuth()
        {
            return Ok(User.Identity.IsAuthenticated);
        }
    }
}
