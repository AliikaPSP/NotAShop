using Microsoft.AspNetCore.Mvc;

namespace NotAShop.Controllers
{
    public class SpaceshipController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
