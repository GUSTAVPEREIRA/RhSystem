namespace RhSystem.Repositories.IServices
{
    using RhSystem.Models;
    using System.Collections.Generic;

    public interface IEmployeesService
    {
        Employees CreateEmployees(Employees employees);
        Employees UpdateEmployees(Employees employees);
        Employees DeleteEmployees(int id);
        Employees GetEmployeesById(int id);
        List<Employees> GetEmployees();
    }
}