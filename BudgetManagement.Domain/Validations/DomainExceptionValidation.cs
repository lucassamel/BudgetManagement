using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Domain.Validations
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string error): base(error) { }
        public static void When(bool hasErrod, string  error)
        {
            if (hasErrod)
            {
                throw new DomainExceptionValidation(error);
            }
        }
    }
}
