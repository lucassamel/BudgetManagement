using BudgetManagement.Domain.Entities.Outlay;
using BudgetManagement.Domain.Validations;

namespace BudgetManagement.Domain.Entities.Account
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool IsAdmin { get; set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        public ICollection<Spent> Spents { get; set; }
        public ICollection<Category> Categories { get; set; }

        public User(int id, string name, string email)
        {
            DomainExceptionValidation.When(id < 0 , "ID must be positive");
            Id = id;
            ValidateDomain(name, email);            
        }

        public User( string name, string email)
        {            
            ValidateDomain(name, email);
        }

        public void SetAdmin(bool isAdmin)
        {
            IsAdmin = isAdmin;  
        }

        public void ChangePassword(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        private void ValidateDomain(string name, string email)
        {
            DomainExceptionValidation.When(name.Length > 200, "Name must have less than 200 characters");
            DomainExceptionValidation.When(name is null, "Name can't be null.");
            DomainExceptionValidation.When(email.Length > 250, "Email must have less than 250 characters");
            DomainExceptionValidation.When(email is null, "Email can't be null.");

            Name = name;
            Email = email;
            IsAdmin = false;
        }
    }
}
