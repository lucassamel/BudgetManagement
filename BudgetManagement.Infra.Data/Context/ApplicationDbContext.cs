﻿using BudgetManagement.Domain.Entities.Account;
using BudgetManagement.Domain.Entities.Outlay;
using Microsoft.EntityFrameworkCore;

namespace BudgetManagement.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Profile> Profile { get; set; }
        public DbSet<Spent> Spent { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
