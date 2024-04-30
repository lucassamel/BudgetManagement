﻿using BudgetManagement.Domain.Entities.Account;
using BudgetManagement.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
