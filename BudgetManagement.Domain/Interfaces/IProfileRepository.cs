using BudgetManagement.Domain.Entities.Account;

namespace BudgetManagement.Domain.Interfaces
{
    public interface IProfileRepository
    {
        Task<Profile> Insert(Profile profile);
        Task<Profile> Update(Profile profile);
        Task<Profile> Delete(int id);
        Task<Profile> Get(int id);
        Task<IEnumerable<Profile>> GetAllAsync();        
    }
}
