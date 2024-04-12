using BudgetManagement.Domain.Entities.User;
using BudgetManagement.Domain.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BudgetManagement.Domain.Entities.Outlay
{
    public class Category
    {        
        public int Id { get; private set; }
        public int IdProfile { get; set; }        
        public string Name { get; private set; }
        public string Description { get; private set; }     
        public Profile Profile { get; set; }
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
            DomainExceptionValidation.When(Name.Length < 0, "Value must be more than zero.");

            Name = name;            
            Description = description;
        }

        public void Update(string name, string description)
        {
            ValidateDomain(name, description);
        }
    }
}
