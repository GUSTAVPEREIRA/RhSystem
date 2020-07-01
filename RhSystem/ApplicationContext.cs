namespace RHSystem
{
    using System;
    using System.Linq;
    using RhSystem.Models;
    using RhSystem.Mappings;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class ApplicationContext : IdentityDbContext
    {
        public DbSet<User> TbUsers { get; set; }
        public DbSet<UserRules> TbUserRules { get; set; }
        public DbSet<Employees> TbEmployees { get; set; }

        public ApplicationContext()
        {

        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new UserMapping().Mapping(ref builder);
            new UserRulesMapping().Mapping(ref builder);
            new EmployeesMapping().Mapping(ref builder);

            base.OnModelCreating(builder);
        }
    }
}