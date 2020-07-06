namespace RhSystem.Models
{
    using System;

    public class Employees
    {
        public int Id { get; set; }
        public decimal Salary { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime? ResignationDate { get; set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; private set; }

        public Employees(decimal salary, DateTime admissionDate)
        {
            if (User == null)
            {
                throw new ArgumentNullException("O funcionário deve possuir um usuário!");
            }

            this.Salary = salary;
            this.AdmissionDate = admissionDate;            
        }

        public void LogicDelete()
        {
            this.DeletedAt = DateTime.UtcNow;
        }
    }
}
