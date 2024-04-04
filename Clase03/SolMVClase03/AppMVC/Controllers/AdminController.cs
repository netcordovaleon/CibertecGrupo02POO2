using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
