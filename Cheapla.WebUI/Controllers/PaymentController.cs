using Microsoft.AspNetCore.Mvc;

namespace Cheapla.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
         
            return View();
        }

        [HttpPost]
        public IActionResult Order()
        {
            TempData["UpdateMessage"] = "Siparişiniz Başarıyla Alındı";

            return RedirectToAction("Index","Home");
       
        }
    }
}
