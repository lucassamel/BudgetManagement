using BudgetManagement.Domain.Entities.Account;

namespace BudgetManagement.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Insert(User profile);
        Task<User> Update(User profile);
        Task<User> Delete(int id);
        Task<User> Get(int id);
        Task<IEnumerable<User>> GetAll();
    }
}
