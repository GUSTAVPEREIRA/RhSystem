namespace RhSystem.Repositories.Services
{
    using System;
    using RHSystem;
    using System.Linq;
    using RhSystem.Models;
    using Microsoft.EntityFrameworkCore;
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
            try
            {
                User user;

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    user = _context.TbUsers.Where(w => w.Username.Equals(username) && w.Password.Equals(password))
                        .Include(i => i.Rules)
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

                user.SetPassword("");

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User DeleteUser(int id)
        {
            try
            {
                User user = this.SerachById(id);
                user.SetDeletedAt();
                _context.Update(user).State = EntityState.Modified;
                _context.SaveChanges();
                user.SetPassword("");
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User GetUserForId(int id)
        {
            try
            {
                User user = this.SerachById(id);
                user.SetPassword("");
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private User SerachById(int id)
        {
            User user = _context.TbUsers.Where(w => w.Id == id).Include(i => i.Rules).AsNoTracking().FirstOrDefault();

            if (user == null)
            {
                throw new Exception("Usuário não encontrado!");
            }
            
            return user;
        }

        public User UpdateUser(User user)
        {
            try
            {
                //Because this as no tracking exist, for two entitys tracking same objeto in this time 
                User updatedUser = _context.TbUsers.Where(w => w.Id == user.Id).AsNoTracking().FirstOrDefault();

                if (updatedUser == null)
                {
                    throw new Exception("Usuário não encontrado!");
                }

                if (updatedUser.DeletedAt != null)
                {
                    throw new Exception("Este usuário não está ativo!");
                }

                _context.Entry(user).State = EntityState.Modified;
                _context.SaveChanges();

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void PhysicalDelete(User user)
        {
            try
            {
                _context.Entry(user).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}