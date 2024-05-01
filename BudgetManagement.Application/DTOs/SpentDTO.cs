using BudgetManagement.Domain.Entities.Outlay;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BudgetManagement.Application.DTOs
{
    public class SpentDTO
    {
        public int Id { get; private set; }
        public int IdCategory { get; set; }
        public int IdProfile { get; set; }
        [Required(ErrorMessage = "Value can't be null.")]
        public int Value { get; private set; }
        [Required(ErrorMessage = "Date can't be null.")]
        public DateOnly Date { get; private set; }
        [MaxLength(200, ErrorMessage = "Description must be less than 200 characters.")]
        public string Description { get; private set; }
        public CategoryDTO Category { get; set; }
        [JsonIgnore]
        public ProfileDTO Profile { get; set; }
    }
}
