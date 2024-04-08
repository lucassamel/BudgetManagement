using Microsoft.AspNetCore.Mvc;

namespace BudgetManagement.Api.Controllers.User
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
