using BudgetManagement.Application.DTOs.Outlay.Spent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Application.Interfaces
{
    public interface ISpentService
    {
        Task<SpentDTO> Insert(SpentPostDTO spentPostDTO);
        Task<SpentDTO> Update(SpentDTO spentDTO);
        Task<SpentDTO> Delete(int id);
        Task<SpentDTO> GetAsync(int id);
        Task<IEnumerable<SpentDTO>> GetAllAsync();
    }
}
