namespace RhSystem.Tests
{
    using Xunit;
    using System;
    using RhSystem.Models;

    public class UserTests
    {
        //Cenário comum
        private User _user = new User("ADMIN", "ADMIN")
        {
            Id = 2,
            RulesId = 1,
            Rules = new UserRules("ADMIN", true, true)
            {
                Id = 1
            }
        };
      
        [Fact(DisplayName = "Desejo criar um usuário!")]
        public void CreateUser()
        {                        
            Assert.Equal(2, _user.Id);
            //Um usuário não pode existir sem uma regra definida.
            Assert.Equal(1, _user.Rules.Id);
        }

        [Fact(DisplayName = "Desejo alterar um usuário!")]
        public void UpdateUser()
        {

            _user.Username = "ADMIN2";

            Assert.Equal("ADMIN2", _user.Username);
        }

        [Fact(DisplayName = "Desejo garantir que o password esteja criptografado!")]
        public void UserPassword()
        {
            _user.SetPassword("ADMIN");
            Assert.NotEqual("ADMIN", _user.Password);
        }

        [Fact(DisplayName = "Desejo garantir que o usuário foi deletado com exclusão lógica!")]
        public void UserLogicDelete()
        {
            //Cenário
            Assert.Equal(new Nullable<DateTime>(), _user.DeletedAt);
            _user.SetDeletedAt();
            Assert.NotEqual(new Nullable<DateTime>(), _user.DeletedAt);
        }

        [Fact(DisplayName = "Desejo garantir que o usuário não esteja mais excluído lógicamente!")]
        public void UserRemoveLogicDelete()
        {
            //Cenário
            _user.SetDeletedAt();

            _user.RemoveDeletedAt();

            Assert.Equal(new Nullable<DateTime>(), _user.DeletedAt);
        }
    }
}