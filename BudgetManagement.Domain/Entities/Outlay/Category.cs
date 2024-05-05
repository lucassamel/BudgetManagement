using BudgetManagement.Domain.Validations;

namespace BudgetManagement.Domain.Entities.Outlay
{
    public class Category
    {        
        public int Id { get; private set; }
        public int IdUser { get; set; }        
        public string Name { get; private set; }
        public string Description { get; private set; }     
        public Account.User User { get; set; }
        public ICollection<Spent> Spents { get; set; }

        public Category(int id, string name, string description)
        {
            DomainExceptionValidation.When(id > 0, "ID must be positive");
            Id = id;
            ValidateDomain(name, description);
        }

        public Category(string name, string description)
        {
            ValidateDomain(name, description);
        }

        public void ValidateDomain(string name, string description)
        {
            DomainExceptionValidation.When(name.Length < 0, "Value must be more than zero.");

            Name = name;            
            Description = description;
        }

        public void Update(string name, string description)
        {
            ValidateDomain(name, description);
        }
    }
}
