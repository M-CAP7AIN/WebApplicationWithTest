using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationWithTest.Controllers;
using WebApplicationWithTest.Dtos;
using WebApplicationWithTest.Models;
using WebApplicationWithTest.Repositories;
using WebApplicationWithTest.Services;

namespace WebApplicationNUnit
{
    public class UserServiceTests
    {
        private string Name {get; set;}
        private string Email { get; set;}
        private int ID {get; set;}

        [SetUp]
        public void SetUp()
        {
            ID = 1;
            Name = "MirMU";
            Email = "smjabarimc7@gmail.com";
        }


        [Test]
        public async Task CreateUser_ValidDto_ReturnsOkResult()
        {
            // Arrange
            var createUserDto = new CreateUserDto
            {
                Name = Name,
                Email = Email
            };

            var mockUserService = new Mock<IUserService>();
            mockUserService
                .Setup(service => service.CreateUserAsync(createUserDto))
                .ReturnsAsync(ID); // Simulate a successful user creation with an ID.

            var controller = new UserController(mockUserService.Object);

            // Act
            var result = await controller.CreateUser(createUserDto) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(1, result.Value);
        }


        [Test]
        public async Task GetUserById_ExistingUser_ReturnsOkResult()
        {
            // Arrange
            var existingUserId = ID;
            var mockUserService = new Mock<IUserService>();
            mockUserService
                .Setup(service => service.GetUserByIdAsync(existingUserId))
                .ReturnsAsync(new UserDto(new User(Name, Email)));

            var controller = new UserController(mockUserService.Object);

            // Act
            var result = await controller.GetUserById(ID) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
        }

    }
}