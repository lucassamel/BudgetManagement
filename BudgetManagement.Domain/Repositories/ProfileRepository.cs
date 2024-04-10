using BudgetManagement.Domain.Data;
using BudgetManagement.Domain.Entities.User;
using BudgetManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Domain.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        private DataContext _context;
        public ProfileRepository(DataContext context)
        {
            _context = context;
        }
        public async void Delete(Profile profile)
        {
            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();
        }

        public async Task<Profile> Get(int id)
        {
            return await _context.Profiles.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Profile>> GetAll()
        {
            return await _context.Profiles.ToListAsync();
        }

        public async void Insert(Profile profile)
        {
           _context.Profiles.Add(profile);
           await _context.SaveChangesAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async void Update(Profile profile)
        {
            _context.Profiles.Entry(profile).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
