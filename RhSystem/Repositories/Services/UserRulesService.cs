namespace RhSystem.Repositories.Services
{
    using System;
    using RHSystem;
    using System.Linq;
    using RhSystem.Models;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
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

        public UserRules GetUserRulesById(int id)
        {
            try
            {
                var userRules = _context.TbUserRules.Where(w => w.Id == id).FirstOrDefault();
                return userRules;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public UserRules UpdateUserRules(UserRules userRules)
        {
            try
            {
                UserRules existUseRules = _context.TbUserRules.Where(w => w.Id == userRules.Id).AsNoTracking().FirstOrDefault();

                if (existUseRules == null)
                {
                    throw new ArgumentException("Regra não encontrada");
                }

                _context.Entry(userRules).State = EntityState.Modified;

                _context.SaveChanges();

                return userRules;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public List<UserRules> GetUserRules()
        {
            try
            {
                List<UserRules> lista = _context.TbUserRules.AsNoTracking().ToList();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }
    }
}