using AutoMapper;
using BudgetManagement.Application.DTOs;
using BudgetManagement.Application.Interfaces;
using BudgetManagement.Domain.Entities.Outlay;
using BudgetManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Application.Services
{
    public class SpentService : ISpentService
    {
        private readonly ISpentRepository _repository;
        private readonly IMapper _mapper;

        public SpentService(ISpentRepository spentRepository, IMapper mapper)
        {
            _repository = spentRepository;
            _mapper = mapper;
        }

        public async Task<SpentDTO> Delete(int id)
        {
            var spent = await _repository.Delete(id);

            return _mapper.Map<SpentDTO>(spent);
        }

        public async Task<SpentDTO> GetAsync(int id)
        {
            var spent = await _repository.GetAsync(id);

            return _mapper.Map<SpentDTO>(spent);
        }

        public async Task<IEnumerable<SpentDTO>> GetAllAsync()
        {
            var spents = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<SpentDTO>>(spents);
        }

        public async Task<SpentDTO> Insert(SpentDTO spentDTO)
        {
            var spent = _mapper.Map<Spent>(spentDTO);
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
