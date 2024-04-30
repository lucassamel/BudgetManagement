using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Application.DTOs
{
    public  class UserDTO
    {
        //public int Id { get; set; }
        [Required(ErrorMessage = "Name can't be null.")]
        [MaxLength(200,ErrorMessage = "Name must have less than 200 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email can't be null.")]
        [MaxLength(250, ErrorMessage = "E-mail must have less than 250 characters.")]
        public string Email { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Password can't be null.")]
        [MaxLength(100, ErrorMessage = "Password must have less than 100 characters.")]
        [MinLength(8,ErrorMessage = "Password must have unlest 7 characters.")]
        public string Password { get; set; }
    }
}
