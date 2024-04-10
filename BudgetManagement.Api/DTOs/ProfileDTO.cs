using System.ComponentModel.DataAnnotations;

namespace BudgetManagement.Api.DTO
{
    public class ProfileDTO
    {
        [Key]
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
