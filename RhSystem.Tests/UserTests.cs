namespace RhSystem.Tests
{
    using Xunit;
    using System;
    using RhSystem.Models;
    using RhSystem.Repositories.Services;
    using RHSystem;
    using Microsoft.EntityFrameworkCore;

    public class UserTests
    {        
        private User _user = new User("ADMIN", "ADMIN")
        {
            Id = 2,
            RulesId = 1,
            Rules = new UserRules("ADMIN", true, true)
            {
                Id = 1
            }
        };

        [Theory(DisplayName = "I want to create a user!")]
        [InlineData("ADMIN", "ADMIN", "ADMIN")]
        [InlineData("JOSE", "JOSE", "123456")]        
        public void CreateUser(string expected, string username, string password)
        {
            //Configures provider
            var options = new DbContextOptionsBuilder<ApplicationContext>().UseInMemoryDatabase("RHSystemTests").Options;
            var context = new ApplicationContext(options);

            //Dependence injection
            var UserService = new UserService(context);

            User user = new User(username, password);
            var createdUser = UserService.CreateUser(user);
            Assert.Equal(expected, createdUser.Username);
        }
        
        [Fact(DisplayName = "I want to change a user!")]
        public void UpdateUser()
        {

            _user.Username = "ADMIN2";

            Assert.Equal("ADMIN2", _user.Username);
        }

        [Fact(DisplayName = "I want to ensure that the password is encrypted!")]
        public void UserPassword()
        {
            _user.SetPassword("ADMIN");
            Assert.NotEqual("ADMIN", _user.Password);
        }

        [Fact(DisplayName = "I want to ensure that the user has been deleted with logical exclusion!")]
        public void UserLogicDelete()
        {
            //Cenário
            Assert.Equal(new Nullable<DateTime>(), _user.DeletedAt);
            _user.SetDeletedAt();
            Assert.NotEqual(new Nullable<DateTime>(), _user.DeletedAt);
        }

        [Fact(DisplayName = "I want to ensure that the user is no longer logically excluded!")]
        public void UserRemoveLogicDelete()
        {
            //Cenário
            _user.SetDeletedAt();

            _user.RemoveDeletedAt();

            Assert.Equal(new Nullable<DateTime>(), _user.DeletedAt);
        }   
        
        [Theory(DisplayName = "I want to ensure that the username and password fields are not empty, if they are throwing an exception!")]
        [InlineData("", "ADMIN")]
        [InlineData("", "")]
        [InlineData("ADMIN", "")]        
        public void UserException(string username, string password)
        {            
            var exception = Assert.Throws<ArgumentNullException>(() => new User(username, password));

            Assert.Equal("Value cannot be null. (Parameter 'Os campos username e password não podem ser vazios!')", exception.Message);
        }
    }
}