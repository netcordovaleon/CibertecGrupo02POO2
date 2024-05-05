using Microsoft.AspNetCore.Mvc;

namespace CiberStore.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
