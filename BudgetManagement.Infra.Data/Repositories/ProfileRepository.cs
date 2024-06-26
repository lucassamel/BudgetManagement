﻿using BudgetManagement.Domain.Entities.Account;
using BudgetManagement.Domain.Interfaces;
using BudgetManagement.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BudgetManagement.Infra.Data.Repositories
{
    public class ProfileRepository(ApplicationDbContext context) : IProfileRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Profile> Delete(int id)
        {
           var profile = await _context.Profile.FindAsync(id);
            if (profile is not null)
                _context.Profile.Remove(profile);

            return profile;
        }

        public async Task<Profile> Get(int id)
        {
            return await _context.Profile.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Profile>> GetAllAsync()
        {
            return await _context.Profile.ToListAsync();
        }

        public async Task<Profile> Insert(Profile profile)
        {
            _context.Profile.Add(profile);
            await _context.SaveChangesAsync();
            return profile;
        }        

        public async Task<Profile> Update(Profile profile)
        {
            _context.Profile.Update(profile);
            await _context.SaveChangesAsync();
            return profile;
        }
    }
}
