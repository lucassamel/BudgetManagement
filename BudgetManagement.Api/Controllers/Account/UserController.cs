using BudgetManagement.Api.Models;
using BudgetManagement.Application.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BudgetManagement.Api.Controllers.Account
{
    [Controller]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        [HttpPost("register")]
        public async Task<IActionResult<UserToken>> Insert(UserDTO userDTO)
        {

            return View();
        }
    }
}
