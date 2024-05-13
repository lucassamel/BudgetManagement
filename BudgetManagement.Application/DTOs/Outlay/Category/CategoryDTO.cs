using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BudgetManagement.Application.DTOs.Account;
using BudgetManagement.Application.DTOs.Outlay.Spent;
using BudgetManagement.Domain.Entities.Account;

namespace BudgetManagement.Application.DTOs.Outlay.Category
{
    public class CategoryDTO
    {
        public int Id { get; set; }       
        [Required(ErrorMessage = "Category Name is required.")]
        [MaxLength(50, ErrorMessage = "Name can't be more than 50 characters.")]
        public string Name { get; set; }
        [MaxLength(200, ErrorMessage = "Description can't be more than 200 characters.")]
        public string Description { get; set; }        
        [JsonIgnore]
        public ICollection<SpentDTO> SpentsDTO { get; set; }
        [JsonIgnore]
        public UserDTO UserDTO { get; set; }
    }
}
