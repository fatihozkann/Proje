using Cheapla.Business.Managers;
using Cheapla.Business.Services;
using Cheapla.WebUI.Extensions;
using Cheapla.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cheapla.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        
        private readonly ICartService _cartService;

        public CartController(IProductService productService, IUserService userService/* UserManager userManager*/, ICartService cartService)
        {
            _productService = productService;
            //_userManager = userManager;
            _cartService = cartService;
            _userService = userService;
        }


        public IActionResult Index()
        {
            var userId = User.GetUserId();
            var cart = _cartService.GetCartByUserId(userId);

            return View(new CartViewModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i => new CartItemsViewModel()
                {

                    ProductId = i.Product.Id,
                    Name = i.Product.Name,
                    UnitPrice = (decimal)i.Product.UnitPrice,
                    ImagePath = i.Product.ImagePath,
                    Quantity = i.Quantity
                }).ToList()
            });
          
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            _cartService.AddToCart(User.GetUserId(), productId, quantity);
            TempData["UpdateMessage"] = "Ürün Sepete Başarıyla Eklendi";

            return RedirectToAction("Index","Home");
        }

        
        [HttpPost]
        public IActionResult DeleteFromCart(int productId)
        {
            _cartService.DeleteFromCart(User.GetUserId(), productId);
            return RedirectToAction("Index");
        }
    }
}
