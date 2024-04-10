using BudgetManagement.Domain.Entities.Outlay;
using BudgetManagement.Domain.Entities.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BudgetManagement.Domain.Data
{
    public class DataContext :IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
