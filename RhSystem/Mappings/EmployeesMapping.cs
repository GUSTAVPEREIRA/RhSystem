namespace RhSystem.Mappings
{
    using System;
    using RhSystem.Models;
    using Microsoft.EntityFrameworkCore;

    public class EmployeesMapping : IMapping
    {
        public void Mapping(ref ModelBuilder builder)
        {
            builder.Entity<Employees>().Property(p => p.CreatedAt).HasDefaultValue(DateTime.UtcNow);
            builder.Entity<Employees>().Property(p => p.UpdatedAt).HasDefaultValue(DateTime.UtcNow);
            builder.Entity<Employees>().Property(p => p.DeletedAt).HasDefaultValue(new Nullable<DateTime>());
            builder.Entity<Employees>().Property(p => p.ResignationDate).HasDefaultValue(new Nullable<DateTime>());
            builder.Entity<Employees>().HasOne(h => h.User);
        }
    }
}