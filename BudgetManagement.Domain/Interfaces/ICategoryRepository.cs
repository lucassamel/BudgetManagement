using BudgetManagement.Domain.Entities.Outlay;

namespace BudgetManagement.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> Insert(Category category);
        Task<Category> Update(Category category);
        Task<Category> Delete(int id);
        Task<Category> GetAsync(int id);
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
