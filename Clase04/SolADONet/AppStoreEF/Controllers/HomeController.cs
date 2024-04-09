using AppStoreEF.DataAccess;
using AppStoreEF.DataAccess.Entities;
using AppStoreEF.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.;
using System.Collections;
namespace AppStoreEF.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private StoreContext _context;
        public HomeController(ILogger<HomeController> logger, StoreContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            var list = (from c in _context.Product.ToList()
                     select new ProductNewEntity()
                     {
                         Id = c.Id,
                         Name = c.Name
                     });

            _context.SaveChanges();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}