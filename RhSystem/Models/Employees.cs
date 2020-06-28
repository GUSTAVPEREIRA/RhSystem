namespace RhSystem.Models
{
    using System;

    public class Employees
    {      
        public int Id { get; set; }

        public decimal Salary { get; set; }

        public User User { get; set; }

        public DateTime AdmissionDate { get; set; }

        public DateTime? ResignationDate { get; set; }

        public Employees(decimal salary, DateTime admissionDate, User user)
        {
            this.Salary = salary;
            this.AdmissionDate = admissionDate;
            this.User = user;
        }
    }
}
