using System.ComponentModel.DataAnnotations;

namespace BudgetManagement.Api.Models
{
    public class PaginationParams
    {
        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; }
        [Range(1,50, ErrorMessage = "The maximum number of items per page is 50.")]
        public int PageSize { get; set; }
    }
}
