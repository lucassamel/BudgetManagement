using BudgetManagement.Application.DTOs.Outlay.Category;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BudgetManagement.Application.DTOs.Outlay.Spent
{
    public class SpentDTO
    {
        public int Id { get; private set; }
        public int IdCategory { get; set; }        
        [Required(ErrorMessage = "Value can't be null.")]
        public decimal Value { get; private set; }
        [Required(ErrorMessage = "Date can't be null.")]
        public DateOnly Date { get; private set; }
        [MaxLength(200, ErrorMessage = "Description must be less than 200 characters.")]
        public string Description { get; private set; }
        public CategoryDTO Category { get; set; }        
    }
}
