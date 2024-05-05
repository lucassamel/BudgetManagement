using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BudgetManagement.Application.DTOs.Outlay.Category
{
    public class CategoryPostDTO
    {
        [JsonIgnore]
        public int IdUser { get; set; }
        [Required(ErrorMessage = "Category Name is required.")]
        [MaxLength(50, ErrorMessage = "Name can't be more than 50 characters.")]
        public string Name { get; set; }
        [MaxLength(200, ErrorMessage = "Description can't be more than 200 characters.")]
        public string Description { get; set; }

    }
}
