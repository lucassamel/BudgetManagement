using AutoMapper;
using BudgetManagement.Api.DTO;
using BudgetManagement.Domain.Entities.User;
using BudgetManagement.Domain.Interfaces;
using BudgetManagement.Domain.Repository;
using Microsoft.AspNetCore.Mvc;
using Profile = BudgetManagement.Domain.Entities.User.Profile;

namespace BudgetManagement.Api.Controllers.User
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProfileController : Controller
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IMapper _mapper;

        public ProfileController(IProfileRepository profileRepository, IMapper mapper)
        {
            _profileRepository = profileRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profile>>> GetAll() 
        {
            var profiles = await _profileRepository.GetAll();
            var profilesDTO = _mapper.Map<IEnumerable<Profile>>(profiles);

            return Ok(profilesDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Profile>> Get(int id)
        {
            Profile profile = await _profileRepository.Get(id);

            if(profile is null)
                return NotFound();

            ProfileDTO profileDTO = _mapper.Map<ProfileDTO>(profile);

            return Ok(profileDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post(ProfileDTO profileDTO)
        {
            var profile = _mapper.Map<Profile>(profileDTO);
            _profileRepository.Insert(profile);
            if (await _profileRepository.SaveAllAsync())
                return Ok();
            
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProfileDTO profileDTO)
        {
            if(profileDTO.Id == 0)
                return BadRequest("Profile ID is required.");

            var profile = _mapper.Map<Profile>(profileDTO);

            if (profile is null)
                return NotFound("Profile not found.");

            _profileRepository.Update(profile);
            if (await _profileRepository.SaveAllAsync())
                return Ok("Profile updated.");

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var profile = await _profileRepository.Get(id);

            if (profile is null)            
                return NotFound("Profile not found.");           

            _profileRepository.Delete(profile);

            if (await _profileRepository.SaveAllAsync())
                return Ok();

            return BadRequest();
        }
    }
}
