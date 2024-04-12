using BudgetManagement.Domain.Entities.User;
using BudgetManagement.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace BudgetManagement.Domain.Entities.Outlay
{
    public class Spent
    {        
        public int Id { get; private set; }
        public int IdCategory { get; set; }
        public int IdProfile { get; set; }
        public int Value { get; private set; }
        public DateOnly Date { get; private set; }
        public string Description { get; private set; } 
        public Category Category { get; set; }
        public Profile Profile { get; set; }

        public Spent(int id,int value, DateOnly date, string description)
        {
            DomainExceptionValidation.When(id > 0, "ID must be positive");
            Id = id;
            ValidateDomain(value, date, description);
        }

        public Spent(int value, DateOnly date, string description)
        {
            ValidateDomain(value,date,description);
        }

        public void ValidateDomain(int value, DateOnly date, string description)
        {
            DomainExceptionValidation.When(value < 0, "Value must be more than zero.");

            Value = value;
            Date = date;
            Description = description;
        }

        public void Update(int value, DateOnly date, string description)
        {
            ValidateDomain(value, date, description);
        }
    }
}
