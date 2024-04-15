using AutoMapper;
using BudgetManagement.Application.DTOs;
using BudgetManagement.Application.Interfaces;
using BudgetManagement.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Profile = BudgetManagement.Domain.Entities.User.Profile;

namespace BudgetManagement.Api.Controllers.User
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly IMapper _mapper;

        public ProfileController(IProfileService profileService, IMapper mapper)
        {
            _profileService = profileService;
            _mapper = mapper;
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
        public async Task<ActionResult> Post(ProfileDTO profileDTO)
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
            var profile = await _profileService.Get(id);

            if (profile is null)            
                return NotFound("Profile not found.");

            await _profileService.Delete(id);           

            return Ok(profile);
        }
    }
}
