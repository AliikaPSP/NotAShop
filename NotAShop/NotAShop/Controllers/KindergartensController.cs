using Microsoft.AspNetCore.Mvc;

namespace NotAShop.Controllers
{
    public class KindergartensController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
