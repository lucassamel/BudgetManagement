using AutoMapper;
using BudgetManagement.Application.DTOs.Outlay.Spent;
using BudgetManagement.Application.Interfaces;
using BudgetManagement.Domain.Entities.Outlay;
using BudgetManagement.Domain.Interfaces;

namespace BudgetManagement.Application.Services
{
    public class SpentService(ISpentRepository spentRepository, IMapper mapper) : ISpentService
    {
        private readonly ISpentRepository _repository = spentRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<SpentDTO> Delete(int id)
        {
            var spent = await _repository.Delete(id);

            return _mapper.Map<SpentDTO>(spent);
        }

        public async Task<SpentDTO> GetAsync(int id, int idUser)
        {            
            var spent = await _repository.GetAsync(id, idUser);

            return _mapper.Map<SpentDTO>(spent);
        }

        public async Task<IEnumerable<SpentDTO>> GetAllAsync(int idUser)
        {
            var spents = await _repository.GetAllAsync(idUser);

            return _mapper.Map<IEnumerable<SpentDTO>>(spents);
        }

        public async Task<SpentDTO> Insert(SpentPostDTO spentPostDTO)
        {
            var spent = _mapper.Map<Spent>(spentPostDTO);
            var spentUpdated = await _repository.Insert(spent);

            return _mapper.Map<SpentDTO>(spentUpdated);
        }

        public async Task<SpentDTO> Update(SpentDTO spentDTO)
        {
            var spent = _mapper.Map<Spent>(spentDTO);
            var spentUpdated = await _repository.Update(spent);

            return _mapper.Map<SpentDTO>(spentUpdated);
        }
    }
}
