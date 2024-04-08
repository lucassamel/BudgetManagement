using BudgetManagement.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Domain.Interfaces
{
    public interface IProfileRepository
    {
        void Insert(Profile profile);
        void Update(Profile profile);
        void Delete(Profile profile);
        Task<Profile> Get(int id);
        Task<IEnumerable<Profile>> GetAll();
        Task<bool> SaveAllAsync();
    }
}
