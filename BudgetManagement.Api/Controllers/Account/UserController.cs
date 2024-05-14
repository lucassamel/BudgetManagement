using BudgetManagement.Api.Models;
using BudgetManagement.Application.DTOs.Account;
using BudgetManagement.Application.Interfaces;
using BudgetManagement.Domain.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BudgetManagement.Api.Controllers.Account
{
    [Controller]
    [Route("api/[controller]")]
    public class UserController(IAuthenticate authenticate, IUserService userService) : Controller
    {
        private readonly IAuthenticate _authenticate = authenticate;
        private readonly IUserService _userService = userService;

        [HttpPost("register")]
        public async Task<ActionResult<UserToken>> Insert(UserDTO userDTO)
        {
            if(userDTO is null)
            {
                return BadRequest("Invalid User.");
            }
            
            var emailExist  = await _authenticate.UserExist(userDTO.Email);

            if(emailExist)
            {
                return BadRequest("This Email already exists.");
            }

            var user = await _userService.Insert(userDTO);
            if(user is null)
            {
                return BadRequest("Occurred an error while register the user.");
            }

            var token = _authenticate.GenerateToken(user.Id, user.Email);

            return new UserToken
            { 
                Token = token 
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Select(LoginModel loginModel)
        {
            var exist = await _authenticate.UserExist(loginModel.Email);
            if (!exist)
                return Unauthorized("User doesn't exist.");

            var result = await _authenticate.Authenticate(loginModel.Email, loginModel.Password);
            if(!result)
                return Unauthorized("Invalid User or Password.");

            var user = await _authenticate.GetUserByEmail(loginModel.Email);
            var token = _authenticate.GenerateToken(user.Id, user.Email);

            return new UserToken
            {
                Token = token
            };
        }
    }
}
