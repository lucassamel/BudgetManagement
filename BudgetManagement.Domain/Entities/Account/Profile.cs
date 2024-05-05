using BudgetManagement.Domain.Validations;

namespace BudgetManagement.Domain.Entities.Account
{
    public class Profile
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string NickName { get; private set; }
        public string Email { get; private set; }        

        public Profile(int id, string firstName, string lastName, string nickName, string email)
        {
            DomainExceptionValidation.When(id < 0, "ID must be positive");
            Id = id;
            ValidateDomain(firstName, lastName, nickName, email);
        }

        public Profile(string firstName, string lastName, string nickName, string email)
        {
            ValidateDomain(firstName, lastName, nickName, email);
        }

        public void ValidateDomain(string firstName, string lastName, string nickName, string email)
        {
            DomainExceptionValidation.When(firstName.Length > 50, "First Name must have less than 50 characters");
            DomainExceptionValidation.When(lastName.Length > 50, "First Name must have less than 50 characters");

            FirstName = firstName;
            LastName = lastName;
            NickName = nickName;
            Email = email;
        }

        public void Update(string firstName, string lastName, string nickName, string email)
        {
            ValidateDomain(firstName, lastName, nickName, email);
        }
    }
}
