using CiberStore.Database;
using CiberStore.Extensiones;
using CiberStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CiberStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly CiberStoreContext _context;
        public ProductController(CiberStoreContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Product.ToList();
            var productsViewModel = (from c in products
                                     select new ProductCatalogViewModel()
                                         {
                                             Id = c.Id,
                                             Name = c.Name,
                                             Image = c.Image,
                                             Price = c.Price,
                                             Stock = c.Stock
                                         }
                                     ).ToList();
            return View(productsViewModel);
        }

        public IActionResult ProductDetail(int id) {
            var product = _context.Product.Where(c=>c.Id == id).SingleOrDefault(); //FirstOrDefault
            var productViewModel = new ProductCatalogViewModel()
            {
                Id = product!.Id,
                Name = product!.Name,
                Image = product!.Image,
                Price = product!.Price,
                Stock = product!.Stock
            };
            return View(productViewModel);
        }


        [HttpPost]
        public JsonResult AddTemporalProduct(int id) {

            List<TemporalShoppingCarViewModel> listadoTemporal = null;

            var tempProducts = HttpContext.Session.GetList<TemporalShoppingCarViewModel>("ProductsCar");

            var product = _context.Product.Where(c => c.Id == id).SingleOrDefault();
            var varItemAdd = new TemporalShoppingCarViewModel()
            {
                ProductId = product!.Id,
                ProductImage = product!.Image,
                ProductName = product!.Name,
                Price = product!.Price,
                Quantity = 1,
            };

            if (tempProducts == null || !tempProducts.Any())
            {
                listadoTemporal = new List<TemporalShoppingCarViewModel>();
            }
            else {
                listadoTemporal = tempProducts;
            }

            listadoTemporal.Add(varItemAdd);
            HttpContext.Session.Set<List<TemporalShoppingCarViewModel>>("ProductsCar", listadoTemporal);

            return Json(new { message = "El producto se añadio correctamente" });
        }

    }
}
