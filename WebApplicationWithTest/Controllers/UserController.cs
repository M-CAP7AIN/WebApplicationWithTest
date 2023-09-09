using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationWithTest.Dtos;
using WebApplicationWithTest.Models;
using WebApplicationWithTest.Services;

namespace WebApplicationWithTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var userId = await _userService.CreateUserAsync(createUserDto);

            //return CreatedAtAction(nameof(GetUserById), new { id = userId }, null);

            return Ok(userId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var userDto = await _userService.GetUserByIdAsync(id);

            if (userDto == null)
            {
                return NotFound();
            }

            return Ok(userDto);
        }
    }
}
