﻿namespace RHSystem
{
    using RhSystem.Models;
    using RhSystem.Mappings;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class ApplicationContext : IdentityDbContext
    {
        public DbSet<User> TbUsers { get; set; }        

        public ApplicationContext()
        {

        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            new UserMapping().Mapping(ref builder);            
            base.OnModelCreating(builder);
        }
    }
}