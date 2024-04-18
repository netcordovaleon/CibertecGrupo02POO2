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
            _context.Products.Add(modelToRegister);
            _context.SaveChanges();
            return RedirectToAction("ListProducts");
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
    }
}
