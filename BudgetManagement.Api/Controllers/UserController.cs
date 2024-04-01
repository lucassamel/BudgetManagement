using BudgetManagement.Domain.Data;
using BudgetManagement.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BudgetManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Account>>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();

            return Ok(users);
        }
        [HttpGet("{id}")]        
        public async Task<ActionResult<Account>> GetUser(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users is null)
            {
                return NotFound("User not found.");
            }

            return Ok(users);
        }
        [HttpPost]
        public async Task<ActionResult<Account>> AddUser(Account account)
        {
            _context.Users.Add(account);
            await _context.SaveChangesAsync();

            return Ok(account);
        }
        [HttpPut]
        public async Task<ActionResult<Account>> UpdateUser(Account account)
        {
            var user = await _context.Users.FindAsync(account.Id);
            if (user is null)
            {
                return NotFound("User not found.");
            }

            user.FirstName = account.FirstName;
            user.LastName = account.LastName;

            await _context.SaveChangesAsync();

            return Ok(account);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Account>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
            {
                return NotFound("User not found.");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }
    }
}
