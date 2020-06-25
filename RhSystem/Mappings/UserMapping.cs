namespace RhSystem.Mappings
{
    using System;
    using RhSystem.Models;
    using Microsoft.EntityFrameworkCore;

    public class UserMapping : IMapping
    {
        public void Mapping(ref ModelBuilder builder)
        {
            builder.Entity<User>().Property(p => p.CreatedAt).HasDefaultValue(DateTime.UtcNow.Date);
            builder.Entity<User>().Property(p => p.UpdatedAt).HasDefaultValue(DateTime.UtcNow.Date);
            builder.Entity<User>().Property(p => p.DeletedAt).HasDefaultValue(new Nullable<DateTime>());
            builder.Entity<User>().Property(i => i.Username).HasMaxLength(30);
            builder.Entity<User>().Property(i => i.Password).HasMaxLength(30);
            builder.Entity<User>().HasIndex(i => i.Username).IsUnique().HasFilter(null);
            builder.Entity<User>().HasOne(h => h.Rules).WithMany(w => w.Users).IsRequired();
        }
    }
}