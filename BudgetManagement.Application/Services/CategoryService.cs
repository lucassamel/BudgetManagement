using AutoMapper;
using BudgetManagement.Application.DTOs.Outlay.Category;
using BudgetManagement.Application.Interfaces;
using BudgetManagement.Domain.Entities.Outlay;
using BudgetManagement.Domain.Interfaces;
using BudgetManagement.Domain.Pagination;

namespace BudgetManagement.Application.Services
{
    public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryService
    {
        private readonly ICategoryRepository _repository = categoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<CategoryDTO> Delete(int id)
        {
            var category = await _repository.Delete(id);

            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO> GetAsync(int id, int idUser)
        {
            var category = await _repository.GetAsync(id, idUser);

            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<PagedList<CategoryDTO>> GetAllAsync(int idUser, int pageNumber, int pageSize)
        {
            var categories = await _repository.GetAllAsync(idUser, pageNumber, pageSize);

             var categoriesDTO = _mapper.Map<IEnumerable<CategoryDTO>>(categories);

            return new PagedList<CategoryDTO>(categoriesDTO,pageNumber,pageSize, categories.TotalCount);
        }

        public async Task<CategoryDTO> Insert(CategoryPostDTO categoryPostDTO)
        {
            var category = _mapper.Map<Category>(categoryPostDTO);
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
