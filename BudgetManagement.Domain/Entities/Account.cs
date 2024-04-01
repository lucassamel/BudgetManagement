using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Domain.Entities
{
    public class Account
    {        
        public int Id { get; set; }
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        public string NickName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    }
}
