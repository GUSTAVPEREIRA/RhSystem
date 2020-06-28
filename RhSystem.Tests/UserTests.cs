namespace RhSystem.Tests
{
    using Xunit;
    using RhSystem.Models;

    public class UserTests
    {        
        [Fact]
        public void CreateUser()
        {
            User user = new User("ADMIN", "ADMIN")
            {
                Id = 2,
                RulesId = 1,
                Rules = new UserRules("ADMIN", true, true)
                {
                    Id = 1
                }
            };
            
            Assert.Equal(2, user.Id);
        }
    }
}