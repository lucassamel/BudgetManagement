using BudgetManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BudgetManagement.Domain.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }

        public DbSet<Account> Users { get; set; }
    }
}
