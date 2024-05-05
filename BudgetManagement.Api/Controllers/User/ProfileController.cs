using BudgetManagement.Application.DTOs.Account;
using BudgetManagement.Application.Interfaces;
using BudgetManagement.Infra.Ioc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetManagement.Api.Controllers.User
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]

    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly IUserService _userService;
       
        public ProfileController(IProfileService profileService, IUserService userService)
        {
            _profileService = profileService;
            _userService = userService;
            
        }

        [HttpGet]
        public async Task<ActionResult> GetAll() 
        {
            var profilesDTO = await _profileService.GetAll();           

            return Ok(profilesDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var profileDTO = await _profileService.Get(id);

            if(profileDTO is null)
                return NotFound("Profile not found.");           

            return Ok(profileDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(ProfileDTO profileDTO)
        {          
           var profile = await _profileService.Insert(profileDTO);

            if (profile is null)
                return BadRequest();

            return Ok("Profile Included!");
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProfileDTO profileDTO)
        {
            var profileDTOUpdated = await _profileService.Update(profileDTO);

            if (profileDTOUpdated is null)
                return BadRequest();

            return Ok("Profile Updated!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = User.GetId();
            var user = await _userService.Get(userId);

            if(!user.IsAdmin)
            {
                return Unauthorized("You don't have permission to exclude a Profile.");
            }

            var profile = await _profileService.Get(id);

            if (profile is null)            
                return NotFound("Profile not found.");

            await _profileService.Delete(id);           

            return Ok(profile);
        }
    }
}
