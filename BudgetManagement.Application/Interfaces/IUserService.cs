using BudgetManagement.Application.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> Insert(UserDTO userDTO);
        Task<UserDTO> Update(UserDTO userDTO);
        Task<UserDTO> Delete(int id);
        Task<UserDTO> Get(int id);
        Task<IEnumerable<UserDTO>> GetAll();
    }
}
