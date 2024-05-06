using BudgetManagement.Domain.Entities.Outlay;
using BudgetManagement.Domain.Interfaces;
using BudgetManagement.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Infra.Data.Repositories
{
    public class SpentRepository : ISpentRepository
    {
        private readonly ApplicationDbContext _context;
        public SpentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Spent> Delete(int id)
        {
            var spent = await _context.Spent.FindAsync(id);
            if (spent is not null)
                _context.Spent.Remove(spent);

            return spent;
        }

        public async Task<Spent?> GetAsync(int id, int idUser)
        {
            return await _context.Spent.Where(x => x.Id == id && x.IdUser == idUser)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Spent>> GetAllAsync(int idUser)
        {
            return await _context.Spent.Where(x => x.IdUser == idUser)
                .ToListAsync();
        }

        public async Task<Spent> Insert(Spent spent)
        {
            _context.Spent.Add(spent);
            await _context.SaveChangesAsync();
            return spent;
        }

        public async Task<Spent> Update(Spent spent)
        {
            _context.Spent.Update(spent);
            await _context.SaveChangesAsync();
            return spent;
        }
    }
}
