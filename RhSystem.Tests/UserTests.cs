namespace RhSystem.Tests
{
    using Moq;
    using Xunit;
    using System;
    using RHSystem;
    using RhSystem.Models;
    using Microsoft.EntityFrameworkCore;
    using RhSystem.Repositories.Services;
    using RhSystem.Repositories.IServices;

    public class UserTests
    {
        private UserService _UserServiceConfigureProvider()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>().UseInMemoryDatabase("RHSystemTests").Options;
            var context = new ApplicationContext(options);
            return new UserService(context);
        }

        [Theory(DisplayName = "I want to create a user!")]
        [InlineData("ADMIN", "ADMIN", "ADMIN")]
        [InlineData("JOSE", "JOSE", "123456")]
        public void CreateUser(string expected, string username, string password)
        {
            //Arrange
            var userService = this._UserServiceConfigureProvider();

            //Act
            User user = new User(username, password);
            var createdUser = userService.CreateUser(user);

            //Assert
            Assert.Equal(expected, createdUser.Username);
        }

        [Fact(DisplayName = "I want to change a user!")]
        public void UpdateUser()
        {

            //Arrange
            var userService = this._UserServiceConfigureProvider();
            User user = userService.CreateUser(new User("ADMIN2", "ADMIN"));

            //Act
            user.Username = "ADMIN3";
            var updatedUser = userService.UpdateUser(user);

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
            Action act = () => repo.CreateUser(new User(username, password));

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
            Action act = () => repo.CreateUser(new User("ADMIN", "ADMIN"));

            //Assert
            Assert.Throws<Exception>(act);
        }
    }
}