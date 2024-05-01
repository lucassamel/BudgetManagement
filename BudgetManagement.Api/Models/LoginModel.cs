using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BudgetManagement.Api.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Name can't be null.")]        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password can't be null.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
