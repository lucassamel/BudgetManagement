using BudgetManagement.Domain.Entities.User;
using BudgetManagement.Domain.Interfaces;
using BudgetManagement.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BudgetManagement.Api.Controllers.User
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProfileController : Controller
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileController(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profile>>> GetAll() 
        {
            return Ok(await _profileRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Profile>> Get(int id)
        {
            return Ok(await _profileRepository.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult> Post(Profile profile)
        {
            _profileRepository.Insert(profile);
            if (await _profileRepository.SaveAllAsync())
                return Ok();
            
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Profile profile)
        {
            _profileRepository.Update(profile);
            if (await _profileRepository.SaveAllAsync())
                return Ok();

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Profile profile = await _profileRepository.Get(id);

            if (profile is null)            
                return BadRequest("Profile not found");           

            _profileRepository.Delete(profile);

            if (await _profileRepository.SaveAllAsync())
                return Ok();

            return BadRequest();
        }
    }
}
