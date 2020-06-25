namespace RhSystem.Seeders
{
    using System;
    using RHSystem;
    using RhSystem.Models;
    using RhSystem.Repositories.IServices;
    using RhSystem.Repositories.IServices.ISeederService;

    public class FirstInstallSeederService : IFirstInstallSeederService
    {
        private readonly ApplicationContext _context;
        private readonly IUserService _userService;

        public FirstInstallSeederService(ApplicationContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public void Seeder()
        {
            try
            {

                UserRules userRules = new UserRules("ADMIN", true, true);                
                User user = new User("ADMIN", "ADMIN");
                user.Rules = userRules;

                if (_userService.GetUser(user.Username, user.Password) != null)
                {
                    throw new Exception("Usuário já está criado no banco de dados!");
                }

                _context.TbUsers.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
    }
}