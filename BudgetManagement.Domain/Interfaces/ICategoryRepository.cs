using BudgetManagement.Domain.Entities.Outlay;
using BudgetManagement.Domain.Pagination;

namespace BudgetManagement.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> Insert(Category category);
        Task<Category> Update(Category category);
        Task<Category> Delete(int id);
        Task<Category?> GetAsync(int id, int idUser);
        Task<PagedList<Category>> GetAllAsync(int idUser, int pageNumber, int pageSize);
    }
}
