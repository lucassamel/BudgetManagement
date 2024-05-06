using BudgetManagement.Domain.Entities.Outlay;

namespace BudgetManagement.Domain.Interfaces
{
    public interface ISpentRepository
    {
        Task<Spent> Insert(Spent category);
        Task<Spent> Update(Spent category);
        Task<Spent> Delete(int id);
        Task<Spent?> GetAsync(int id, int idUser);
        Task<IEnumerable<Spent>> GetAllAsync(int idUser);
    }
}
