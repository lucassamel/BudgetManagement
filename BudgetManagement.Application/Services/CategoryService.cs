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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;       

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _repository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Delete(int id)
        {
            var category = await _repository.Delete(id);

            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO> GetAsync(int id)
        {
            var category = await _repository.GetAsync(id);

            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var categorys = await _repository.GetAllAsync();

            return _mapper.Map<IEnumerable<CategoryDTO>>(categorys);
        }

        public async Task<CategoryDTO> Insert(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            var categoryUpdated = await _repository.Insert(category);

            return _mapper.Map<CategoryDTO>(categoryUpdated);
        }

        public async Task<CategoryDTO> Update(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            var categoryUpdated = await _repository.Update(category);

            return _mapper.Map<CategoryDTO>(categoryUpdated);
        }
    }
}
