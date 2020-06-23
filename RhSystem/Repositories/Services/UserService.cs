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

        public User GetUserForAuthenticate(string username, string password)
        {
            try
            {
                User user = _context.TbUsers.Where(w => w.Username.Equals(username) && w.Password.Equals(password))
                    .FirstOrDefault();
                
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }
    }
}