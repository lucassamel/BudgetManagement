using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Application.DTOs.Outlay.Category
{
    public class CategoryPutDTO
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Category Name is required.")]
        [MaxLength(50, ErrorMessage = "Name can't be more than 50 characters.")]
        public string Name { get; set; }
        [MaxLength(200, ErrorMessage = "Description can't be more than 200 characters.")]
        public string Description { get; set; }
    }
}
