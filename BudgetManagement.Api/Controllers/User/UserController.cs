using BudgetManagement.Domain.Data;
using BudgetManagement.Domain.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BudgetManagement.Api.Controllers.User
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
        public async Task<ActionResult<List<Profile>>> GetAllUsers()
        {
            var users = await _context.Profiles.ToListAsync();

            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Profile>> GetUser(int id)
        {
            var users = await _context.Profiles.FindAsync(id);
            if (users is null)
            {
                return NotFound("User not found.");
            }

            return Ok(users);
        }
        [HttpPost]
        public async Task<ActionResult<Profile>> AddUser(Profile profile)
        {
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();

            return Ok(profile);
        }
        [HttpPut]
        public async Task<ActionResult<Profile>> UpdateUser(Profile profile)
        {
            var user = await _context.Profiles.FindAsync(profile.Id);
            if (user is null)
            {
                return NotFound("User not found.");
            }

            user.FirstName = profile.FirstName;
            user.LastName = profile.LastName;

            await _context.SaveChangesAsync();

            return Ok(profile);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Profile>> DeleteUser(int id)
        {
            var user = await _context.Profiles.FindAsync(id);
            if (user is null)
            {
                return NotFound("User not found.");
            }

            _context.Profiles.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }
    }
}
