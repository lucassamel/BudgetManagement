using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManagement.Domain.Entities.Outlay
{
    public class Spent
    {
        [Key] 
        public int Id { get; set; }
        public int Value { get; set; }
        public DateOnly Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public required Category Category { get; set; }
    }
}
