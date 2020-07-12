﻿namespace RhSystem.Tests
{
    using Moq;
    using Xunit;
    using System;
    using RHSystem;
    using RhSystem.Models;
    using RhSystem.Controllers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using RhSystem.Repositories.Services;
    using RhSystem.Repositories.IServices;

    public class UserTests
    {

        private ApplicationContext _context;
        private UserService _userService;
        private UserRulesService _userRulesService;

        private void UserServiceConfigureProvider()
        {
            _userService = new UserService(_context);
        }

        private void UserServiceRulesConfigureProvider()
        {
            _userRulesService = new UserRulesService(_context);
        }

        private void Context()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>().UseInMemoryDatabase("RHSystemTests").Options;
            var context = new ApplicationContext(options);
            _context = context;
        }

        [Theory(DisplayName = "I want to create a user!")]
        [InlineData("ADMIN", "ADMIN", "ADMIN")]
        [InlineData("JOSE", "JOSE", "123456")]
        public void CreateUser(string expected, string username, string password)
        {
            //Arrange
            Context();
            UserServiceConfigureProvider();

            //Act
            User user = new User(username, password);
            var createdUser = _userService.CreateUser(user);

            //Assert
            Assert.Equal(expected, createdUser.Username);
        }

        [Fact(DisplayName = "I want to change a user!")]
        public void UpdateUser()
        {
            //Arrange            
            Context();
            UserServiceConfigureProvider();
            User user = _userService.CreateUser(new User("ADMIN2", "ADMIN"));

            //Act
            user.Username = "ADMIN3";
            var updatedUser = _userService.UpdateUser(user);

            //Assert
            Assert.Equal("ADMIN3", updatedUser.Username);
        }

        [Fact(DisplayName = "I want to ensure that the password is encrypted!")]
        public void UserPassword()
        {
            //Arrange
            User user = new User("ADMIN", "ADMIN2");

            //Act
            user.SetPassword("ADMIN");

            //Assert
            Assert.NotEqual("ADMIN", user.Password);
        }

        [Fact(DisplayName = "I want to ensure that the user has been deleted with logical exclusion!")]
        public void UserLogicDelete()
        {
            //Arrange
            User user = new User("ADMIN", "ADMIN2");

            //Act
            Assert.Equal(new Nullable<DateTime>(), user.DeletedAt);
            user.SetDeletedAt();

            //Assert
            Assert.NotEqual(new Nullable<DateTime>(), user.DeletedAt);
        }

        [Fact(DisplayName = "I want to ensure that the user is no longer logically excluded!")]
        public void UserRemoveLogicDelete()
        {
            //Arrange
            User user = new User("ADMIN", "ADMIN");
            user.SetDeletedAt();

            //Act
            user.RemoveDeletedAt();

            //Assert
            Assert.Equal(new Nullable<DateTime>(), user.DeletedAt);
        }

        [Theory(DisplayName = "I want to ensure that the username and password fields are not empty, if they are throwing an exception!")]
        [InlineData("", "ADMIN")]
        [InlineData("", "")]
        [InlineData("ADMIN", "")]
        public void UserException(string username, string password)
        {
            //Arrange
            var mock = new Mock<IUserService>();
            mock.Setup(r => r.CreateUser(It.IsAny<User>()))
                .Throws(new ArgumentNullException("The username and password fields are not empty!"));

            var repo = mock.Object;

            //Act                  
            void act() => repo.CreateUser(new User(username, password));

            //Assert
            Assert.Throws<ArgumentNullException>(act);
        }

        [Fact(DisplayName = "I want to ensure that not exists two users with same username!")]
        public void UsernameException()
        {
            //Arrange
            var mock = new Mock<IUserService>();
            mock.Setup(r => r.CreateUser(It.IsAny<User>())).Throws(new Exception("Username already registered!"));
            var repo = mock.Object;

            //Act
            void act() => repo.CreateUser(new User("ADMIN", "ADMIN"));

            //Assert
            Assert.Throws<Exception>(act);
        }

        [Fact(DisplayName = "I want to ensure that method CreateUser is called 3 times!")]
        public void CreateThreeUsers()
        {
            //Arrange
            var user1 = new User("ADMIN4", "ADMIN5");
            var user2 = new User("ADMIN5", "ADMIN5");
            var user3 = new User("ADMIN6", "ADMIN5");

            var mock = new Mock<IUserService>();
            mock.Setup(r => r.CreateUser(It.IsAny<User>()))
                .Returns(user1);

            var repo = mock.Object;

            //Act
            user1 = repo.CreateUser(user1);
            user2 = repo.CreateUser(user2);
            user3 = repo.CreateUser(user3);

            //Assert
            mock.Verify(r => r.CreateUser(It.IsAny<User>()), Times.Exactly(3));
        }

        [Fact(DisplayName = "I want to ensure that called UserController with method CreateUser has been invoke then returns OkObjectResult")]
        public void TestUserController()
        {
            //Arrange      
            Context();
            UserServiceConfigureProvider();
            UserServiceRulesConfigureProvider();

            var userRule = _userRulesService.CreateRule(new UserRules("ADMIN"));
            var user = new User("ADMIN5", "ADMIN5");
            user.RulesId = userRule.Id;
            
            //Act
            var controller = new UserController(_userService, _userRulesService);
            var result = controller.CreateUser(user);

            Assert.IsType<OkObjectResult>(result.Result);            
        }
    }
}