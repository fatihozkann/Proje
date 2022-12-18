using Microsoft.AspNetCore.Mvc;

namespace Cheapla.WebUI.Controllers
{
    public class CampaignController : Controller
    {
        [Route("Kampanya")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Kampanya2")]
        public IActionResult Discount()
        {
            return View(); 
        }
        [Route("Kampanya3")]
        public IActionResult Cargo()
        {
            return View();
        }

        [Route("Kampanya4")]
        public IActionResult CheaplaWinter()
        {
            return View();
        }
    }
}
