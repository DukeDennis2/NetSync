using Microsoft.AspNetCore.Mvc;

namespace aspnetproject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}