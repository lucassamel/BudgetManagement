using BudgetManagement.Application.DTOs.Outlay.Category;
using BudgetManagement.Domain.Pagination;

namespace BudgetManagement.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDTO> Insert(CategoryPostDTO categoryPostDTO);
        Task<CategoryDTO> Update(CategoryDTO categoryDTO);
        Task<CategoryDTO> Delete(int id);
        Task<CategoryDTO> GetAsync(int id, int idUser);
        Task<PagedList<CategoryDTO>> GetAllAsync(int idUser, int pageNumber, int pageSize);
    }
}
