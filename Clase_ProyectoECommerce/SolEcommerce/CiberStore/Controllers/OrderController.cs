using CiberStore.Database;
using CiberStore.Database.Entities;
using CiberStore.Extensiones;
using CiberStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CiberStore.Controllers
{
    public class OrderController : Controller
    {
        CiberStoreContext _context;
        public OrderController(CiberStoreContext context)
        {
            _context = context;
        }

        public IActionResult ShoppingCar()
        {
            var model = new OrderDetailViewModel();
            model.ProductsToConfirm = HttpContext.Session.GetList<TemporalShoppingCarViewModel>("ProductsCar");
            return View(model);
        }

        [HttpGet]
        public JsonResult GetClientByIdentityNumber(string identityNumber) {
            var client = _context.Client.Where(c => c.IdentityNumber == identityNumber).SingleOrDefault();
            return Json(client);
        }

        [HttpPost]
        public JsonResult SaveConfirmOrder(OrderDetailViewModel model) {

            model.ProductsToConfirm = HttpContext.Session.GetList<TemporalShoppingCarViewModel>("ProductsCar");

            var clientInDB = _context.Client.Add(new ClientEntity()
            {
                FullName = model.Client.FullName,
                IdentityNumber = model.Client.IdentityNumber,
                DeliveryAddress = model.Client.DeliveryAddress,
            });

            var orderInDB = _context.Order.Add(new OrderEntity()
            {
                Client = clientInDB.Entity,
                registerDate = DateTime.Now,
            });

            foreach (var item in model.ProductsToConfirm)
            {
                var productToSave =  _context.Product.SingleOrDefault(c => c.Id == item.ProductId);
                _context.OrderDetail.Add(new OrderDetailEntity()
                {
                    Order = orderInDB.Entity,
                    Product = productToSave,
                });
            }
            _context.SaveChanges();

            return Json(new { message = $"La orden #{orderInDB.Entity.Id} fue creada con exito." });

        }
    }
}
