using AutoMapper;
using BudgetManagement.Application.DTOs;
using BudgetManagement.Application.Interfaces;
using BudgetManagement.Domain.Entities.User;
using BudgetManagement.Domain.Interfaces;
using Profile = BudgetManagement.Domain.Entities.User.Profile;

namespace BudgetManagement.Application.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _repository;
        private readonly IMapper _mapper;

        public ProfileService(IProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

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
            var profiles = await _repository.GetAll();

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
