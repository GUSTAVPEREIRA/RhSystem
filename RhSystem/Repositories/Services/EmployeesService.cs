namespace RhSystem.Repositories.Services
{
    using System;
    using RHSystem;
    using System.Linq;
    using RhSystem.Models;
    using Microsoft.EntityFrameworkCore;
    using RhSystem.Repositories.IServices;
    using System.Collections.Generic;

    public class EmployeesService : IEmployeesService
    {

        private readonly ApplicationContext _context;
        private readonly IUserService _userService;

        public EmployeesService(ApplicationContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public Employees CreateEmployees(Employees employees)
        {
            try
            {
                User user = _userService.GetUserForId(employees.User.Id);
                
                if (user == null)
                {
                    throw new ArgumentNullException("Usuário não existe!");
                }

                _context.TbEmployees.Add(employees);

                return employees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Employees DeleteEmployees(int id)
        {
            try
            {
                Employees employees = this.GetEmployeesById(id);
                employees.LogicDelete();

                _context.Entry(employees).State = EntityState.Modified;
                _context.SaveChanges();

                return employees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Employees> GetEmployees()
        {
            try
            {
                var lista = _context.TbEmployees.AsNoTracking().ToList();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Employees GetEmployeesById(int id)
        {
            try
            {
                Employees employees = _context.TbEmployees.Where(w => w.Id == id).FirstOrDefault();
                this.EmployeesExist(employees);
                employees.LogicDelete();

                return employees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Employees UpdateEmployees(Employees employees)
        {
            try
            {

                var exist = _context.TbEmployees.Where(w => w.Id == employees.Id).FirstOrDefault();
                this.EmployeesExist(exist);                

                _context.Entry(employees).State = EntityState.Modified;
                _context.SaveChanges();

                return employees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EmployeesExist(Employees employees)
        {
            if (employees != null)
            {
                throw new ArgumentNullException($"O funcionário não foi encontrado!");
            }
        }
    }
}