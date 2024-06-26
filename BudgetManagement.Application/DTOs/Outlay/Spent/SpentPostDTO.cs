﻿using System.ComponentModel.DataAnnotations;

namespace BudgetManagement.Application.DTOs.Outlay.Spent
{
    public class SpentPostDTO
    {
        [Required(ErrorMessage = "Category ID is required.")]
        public int IdCategory { get; set; }
        [Required(ErrorMessage = "Profile ID is required.")]
        public int IdProfile { get; set; }
        [Required(ErrorMessage = "Value can't be null.")]
        [Range(0, (double)decimal.MaxValue)]
        public decimal Value { get; set; }
        [Required(ErrorMessage = "Date can't be null.")]
        public DateOnly Date { get; set; }
        [MaxLength(200, ErrorMessage = "Description must be less than 200 characters.")]
        public string Description { get; set; }                
    }
}
