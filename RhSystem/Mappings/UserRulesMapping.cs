namespace RhSystem.Mappings
{
    using System;
    using RhSystem.Models;
    using Microsoft.EntityFrameworkCore;

    public class UserRulesMapping : IMapping
    {
        public void Mapping(ref ModelBuilder builder)
        {
            builder.Entity<UserRules>().Property(p => p.CreatedAt).HasDefaultValue(DateTime.UtcNow.Date);
            builder.Entity<UserRules>().Property(p => p.UpdatedAt).HasDefaultValue(DateTime.UtcNow.Date);
            builder.Entity<UserRules>().Property(p => p.DeletedAt).HasDefaultValue(new Nullable<DateTime>());            
        }
    }
}
