using BudgetManagement.Domain.Entities.Account;

namespace BudgetManagement.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> UserExist(string email);
        public string GenerateToken(int id, string email);
        public Task<User> GetUserByEmail(string email);
    }
}
