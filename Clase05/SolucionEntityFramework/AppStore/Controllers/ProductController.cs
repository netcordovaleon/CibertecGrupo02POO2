using AppStore.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace AppStore.Controllers
{
    public class ProductController : Controller
    {
        BDStoreContext _context;
        public ProductController(BDStoreContext context)
        {
            this._context = context;
        }

        public IActionResult ListProducts()
        {
            var list = _context.Products.ToList(); // SELECT * FROM PRODUCTS
            return View(list);
        }

        public IActionResult AddProduct() {

            return View();
        }
    }
}
