using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BudgetManagement.Application.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [JsonIgnore]
        public int IdProfile { get; set; }
        [Required(ErrorMessage = "Category Name is required.")]
        [MaxLength(50, ErrorMessage = "Name can't be more than 50 characters.")]
        public string Name { get; set; }
        [MaxLength(200, ErrorMessage = "Description can't be more than 200 characters.")]
        public string Description { get; set; }
        [JsonIgnore]
        public ProfileDTO ProfileDTO { get; set; }
        [JsonIgnore]
        public ICollection<SpentDTO> SpentsDTO { get; set; }
    }
}
