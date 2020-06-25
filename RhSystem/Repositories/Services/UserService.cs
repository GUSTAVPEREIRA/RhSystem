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

        public User CreateUserAsync(User user)
        {
            return null;
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
            try
            {
                User user;

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    user = _context.TbUsers.Where(w => w.Username.Equals(username) && w.Password.Equals(password))
                    .FirstOrDefault();
                }
                else
                {
                    user = _context.TbUsers.Where(w => w.Username.Equals(username)).FirstOrDefault();
                }

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User CreateUser(User user)
        {
            try
            {
                if (this.SearchUser(user.Username, null) != null)
                {
                    throw new Exception("Este username já existe!, Por favor informe outro!");
                }

                this._context.TbUsers.Add(user);
                this._context.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}