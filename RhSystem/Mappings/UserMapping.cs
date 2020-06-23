namespace RhSystem.Mappings
{
    using System;
    using RhSystem.Models;
    using Microsoft.EntityFrameworkCore;

    public class UserMapping
    {
        public void Mapping(ref ModelBuilder builder)
        {
            builder.Entity<User>().Property(p => p.CreatedAt).HasDefaultValue(DateTime.Now);
            builder.Entity<User>().Property(p => p.UpdatedAt).HasDefaultValue(DateTime.Now);
            builder.Entity<User>().Property(p => p.DeletedAt).HasDefaultValue(new Nullable<DateTime>());
            builder.Entity<User>().HasIndex(i => i.Username).IsUnique().HasFilter(null);
        }
    }
}