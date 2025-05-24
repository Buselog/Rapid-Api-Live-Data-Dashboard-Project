using Microsoft.AspNetCore.Mvc;

namespace RapidAPIProject.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
