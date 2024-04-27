using AppStore.DataAccess;
using AppStore.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            var var1 = TempData["ProductName"];
            var var2 = ViewData["ProductName"];
            var var3 = ViewBag.ProductName;
            return View(list);
        }

        public IActionResult AddProduct() {
            ProductEntity model = new ProductEntity();
            model.RegisterDate = DateTime.Now;
            return View(model);
        }

        [HttpPost]
        public IActionResult AddProductPost(ProductEntity modelToRegister)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(modelToRegister);
                _context.SaveChanges();
                TempData["ProductName"] = modelToRegister.Name;
                ViewData["ProductName"] = modelToRegister.Name;
                ViewBag.ProductName = modelToRegister.Name;
                return RedirectToAction("ListProducts");
            }
            else {
                return View("AddProduct", modelToRegister);                           
            }
        }

        public IActionResult EditProduct(int id) {

            var modelProduct = _context.Products.Where(c => c.Id == id).SingleOrDefault();
            //SELECT * FROM PRODUCT WHERE ID = @id
            return View(modelProduct);
        }

        [HttpPost]
        public IActionResult EditProductPost(ProductEntity modelToView) {

            var productToUpdate = _context.Products.Where(c => c.Id == modelToView.Id).SingleOrDefault();
            productToUpdate.Name = modelToView.Name;
            productToUpdate.Stock = modelToView.Stock;
            productToUpdate.Price = modelToView.Price;
            productToUpdate.RegisterDate = modelToView.RegisterDate;
            _context.SaveChanges();
            return RedirectToAction("ListProducts");
        }

        public IActionResult DeleteProduct(int id) {
            var productToDelete = _context.Products.Where(c => c.Id == id).SingleOrDefault();
            _context.Products.Remove(productToDelete);
            _context.SaveChanges();
            return RedirectToAction("ListProducts");
        }


        [HttpGet]
        public IActionResult PostObtenerTotalDeProductos() {

            var totalDeProductos = _context.Products.ToList().Count();
            TempData["TotalRegistros"] = totalDeProductos;
            return RedirectToAction("ListProducts");
        }


        [HttpGet]
        public JsonResult GetTotalDeProductosAjax() {
            var totalDeProductos = _context.Products.ToList().Count();
            return Json(totalDeProductos);
        }


        [HttpGet]
        public JsonResult GetProductsByAjax(string filtro) {
            var listado = new List<ProductEntity>();
            if (string.IsNullOrEmpty(filtro)) {
                listado = _context.Products.ToList();
            } else { 
                listado = _context.Products.Where(c => c.Name.Contains(filtro)).ToList();
            }
            return Json(listado);
        }

    }
}
