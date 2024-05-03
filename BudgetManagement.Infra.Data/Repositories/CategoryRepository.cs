using BudgetManagement.Domain.Entities.Outlay;
using BudgetManagement.Domain.Entities.User;
using BudgetManagement.Domain.Interfaces;
using BudgetManagement.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Category> Delete(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category is not null)
                _context.Category.Remove(category);

            return category;
        }

        public async Task<Category> GetAsync(int id)
        {
            return await _context.Category.Where(x => x.Id == id).
                Include(x => x.Profile)
                .Include(x => x.Spents).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync(int id)
        {
            return await _context.Category
                .Where(x => x.IdProfile == id)
                .Include(x => x.Profile)
                .Include(x => x.Spents).ToListAsync();
        }

        public async Task<Category> Insert(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> Update(Category category)
        {
            _context.Category.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
