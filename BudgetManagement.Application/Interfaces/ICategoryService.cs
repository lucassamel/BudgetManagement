using BudgetManagement.Application.DTOs.Outlay.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDTO> Insert(CategoryPostDTO categoryPostDTO);
        Task<CategoryDTO> Update(CategoryDTO categoryDTO);
        Task<CategoryDTO> Delete(int id);
        Task<CategoryDTO> GetAsync(int id);
        Task<IEnumerable<CategoryDTO>> GetAllAsync(int id);
    }
}
