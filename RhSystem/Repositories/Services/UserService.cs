namespace RhSystem.Repositories.Services
{
    using System;
    using RHSystem;
    using System.Linq;
    using RhSystem.Models;
    using RhSystem.Repositories.IServices;

    public class UserService : IUserService
    {

        private readonly ApplicationContext _context;

        public UserService(ApplicationContext context)
        {
            _context = context;
        }

        public User GetUser(string username, string password)
        {
            try
            {
                User user = this.SearchUser(username, password);
                
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public User GetUserForAuthenticate(string username, string password)
        {
            try
            {
                User user = this.SearchUser(username, password);

                if (user == null)
                {
                    throw new Exception("Username ou Senha inválidos!");
                }

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

        private User SearchUser(string username, string password)
        {
            User user = _context.TbUsers.Where(w => w.Username.Equals(username) && w.Password.Equals(password))
                    .FirstOrDefault();

            return user;
        }
    }
}