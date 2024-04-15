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
        Task<Profile> Insert(Profile profile);
        Task<Profile> Update(Profile profile);
        Task<Profile> Delete(int id);
        Task<Profile> Get(int id);
        Task<IEnumerable<Profile>> GetAll();        
    }
}
