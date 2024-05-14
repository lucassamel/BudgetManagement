using BudgetManagement.Api.Extensions;
using BudgetManagement.Api.Models;
using BudgetManagement.Application.DTOs.Outlay.Category;
using BudgetManagement.Application.Interfaces;
using BudgetManagement.Infra.Ioc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BudgetManagement.Api.Controllers.Outlay
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CategoryController(ICategoryService categoryService, IUserService userService) : ControllerBase
    {
        private readonly ICategoryService _categoryService = categoryService;
        private readonly IUserService _userService = userService;

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery]PaginationParams paginationParams)
        {
            //Retrieve all user's Categories
            var categoriesDTO = await _categoryService.GetAllAsync(User.GetId()
                , paginationParams.PageNumber,paginationParams.PageSize);

            Response.AddPaginationHeader(new PaginationHeader(categoriesDTO.CurrentPage,
                categoriesDTO.PageSize, categoriesDTO.TotalCount, categoriesDTO.TotalPages));

            return Ok(categoriesDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var categoryDTO = await _categoryService.GetAsync(id, User.GetId());

            if (categoryDTO is null)
                return NotFound("Category not found.");

            return Ok(categoryDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Insert(CategoryPostDTO categoryPostDTO)
        {
            //Retrieve the UserID from the JWT token
            categoryPostDTO.IdUser = User.GetId();
            var category = await _categoryService.Insert(categoryPostDTO);

            if (category is null)
                return BadRequest();

            return Ok("Category Included!");
        }

        [HttpPut]
        public async Task<ActionResult> Update(CategoryPutDTO categoryPutDTO)
        {
            var categoryDTO = await _categoryService.GetAsync(categoryPutDTO.Id, User.GetId());
            if (categoryDTO is null)
                return BadRequest("Category not found.");

            categoryDTO.Name = categoryPutDTO.Name;
            categoryDTO.Description = categoryPutDTO.Description;

            var categoryDTOUpdated = await _categoryService.Update(categoryDTO);

            if (categoryDTOUpdated is null)
                return BadRequest("An error occurred while changing the Category.");

            return Ok("Category Updated!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = User.GetId();
            var user = await _userService.Get(userId);

            if (!user.IsAdmin)
            {
                return Unauthorized("You don't have permission to exclude a Category.");
            }

            var category = await _categoryService.GetAsync(id, User.GetId());

            if (category is null)
                return NotFound("Category not found.");

            await _categoryService.Delete(id);

            return Ok(category);
        }
    }
}
