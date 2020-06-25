namespace RhSystem.Repositories.Services
{
    using System;
    using RHSystem;
    using RhSystem.Models;
    using RhSystem.Repositories.IServices;

    public class UserRulesService : IUserRulesService
    {

        private readonly ApplicationContext _context;

        public UserRulesService(ApplicationContext context)
        {
            _context = context;
        }

        public UserRules CreateRule(UserRules userRules)
        {
            try
            {
                _context.TbUserRules.Add(userRules);
                _context.SaveChanges();

                return userRules;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}