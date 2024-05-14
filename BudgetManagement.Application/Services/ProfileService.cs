using AutoMapper;
using BudgetManagement.Application.DTOs.Account;
using BudgetManagement.Application.Interfaces;
using BudgetManagement.Domain.Interfaces;
using Profile = BudgetManagement.Domain.Entities.Account.Profile;

namespace BudgetManagement.Application.Services
{
    public class ProfileService(IProfileRepository repository, IMapper mapper) : IProfileService
    {
        private readonly IProfileRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<ProfileDTO> Delete(int id)
        {
            var profile = await _repository.Delete(id);

            return _mapper.Map<ProfileDTO>(profile);
        }

        public async Task<ProfileDTO> Get(int id)
        {
            var profile = await _repository.Get(id);

            return _mapper.Map<ProfileDTO>(profile);
        }

        public async Task<IEnumerable<ProfileDTO>> GetAll()
        {
            var profiles = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<ProfileDTO>>(profiles);
        }

        public async Task<ProfileDTO> Insert(ProfileDTO profileDTO)
        {
            var profile = _mapper.Map<Profile>(profileDTO);
            var profileUpdated = await _repository.Insert(profile);

            return _mapper.Map<ProfileDTO>(profileUpdated);
        }        

        public async Task<ProfileDTO> Update(ProfileDTO profileDTO)
        {
            var profile = _mapper.Map<Profile>(profileDTO);
            var profileUpdated = await _repository.Update(profile);

            return _mapper.Map<ProfileDTO>(profileUpdated);
        }
       
    }
}
