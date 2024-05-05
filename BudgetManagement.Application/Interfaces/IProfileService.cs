using BudgetManagement.Application.DTOs.Account;
using BudgetManagement.Domain.Entities.User;

namespace BudgetManagement.Application.Interfaces
{
    public interface IProfileService
    {
        Task<ProfileDTO> Insert(ProfileDTO profileDTO);
        Task<ProfileDTO> Update(ProfileDTO profileDTO);
        Task<ProfileDTO> Delete(int id);
        Task<ProfileDTO> Get(int id);
        Task<IEnumerable<ProfileDTO>> GetAll();        
    }
}
