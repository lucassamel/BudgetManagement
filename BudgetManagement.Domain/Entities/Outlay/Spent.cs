using BudgetManagement.Domain.Validations;

namespace BudgetManagement.Domain.Entities.Outlay
{
    public class Spent
    {        
        public int Id { get; private set; }
        public int IdCategory { get; set; }        
        public int IdUser { get; set; }
        public decimal Value { get; private set; }
        public DateOnly Date { get; private set; }
        public string Description { get; private set; } 
        public Category Category { get; set; }       
        public Account.User User { get; set; }

        public Spent(int id,decimal value, DateOnly date, string description)
        {
            DomainExceptionValidation.When(id > 0, "ID must be positive");
            Id = id;
            ValidateDomain(value, date, description);
        }

        public Spent(decimal value, DateOnly date, string description)
        {
            ValidateDomain(value,date,description);
        }

        public void ValidateDomain(decimal value, DateOnly date, string description)
        {
            DomainExceptionValidation.When(value < 0, "Value must be more than zero.");

            Value = value;
            Date = date;
            Description = description;
        }

        public void Update(decimal value, DateOnly date, string description)
        {
            ValidateDomain(value, date, description);
        }
    }
}
