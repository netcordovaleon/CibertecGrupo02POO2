using AppMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppMVC.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            var model = new StudentsViewModel();
            return View(model);
        }

    }
}
