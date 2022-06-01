using Microsoft.AspNetCore.Mvc;
using Webmarket.Modelss.ViewModel;
using WebMarket.DataAccess.Services.Interface;

namespace WebMarketBook.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IProductService _productService;

        public HomeController(IProductService productService )
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            var products = _productService.GetAll();
            return View(products);
        }
        [HttpGet]
        public IActionResult ProductDetails(int id)
        {
            ShoppingCartVM shoppingCart = new ShoppingCartVM
            {
                Product = _productService.GetFirstOrDefault(p => p.Id== id),
                Count = 1
            };

            return View(shoppingCart);
        }
    }
}
