using BudgetManagement.Domain.Entities.Outlay;
using BudgetManagement.Domain.Interfaces;
using BudgetManagement.Domain.Pagination;
using BudgetManagement.Infra.Data.Context;
using BudgetManagement.Infra.Data.Helpers;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Category?> GetAsync(int id, int idUser)
        {
            return await _context.Category.Where(x => x.Id == id && x.IdUser == idUser)
                .Include(x => x.User)
                .Include(x => x.Spents).FirstOrDefaultAsync();
        }

        public async Task<PagedList<Category>> GetAllAsync(int idUser, int pageNumber, int pageSize)
        {
            var query = _context.Category
                .Where(x => x.IdUser == idUser)
                .Include(x => x.User)
                .Include(x => x.Spents).AsQueryable();

            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
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
