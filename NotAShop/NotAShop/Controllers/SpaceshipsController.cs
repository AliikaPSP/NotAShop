using Microsoft.AspNetCore.Mvc;
using NotAShop.Data;
using NotAShop.Models.Spaceships;

namespace NotAShop.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly NotAShopContext _context;
        public SpaceshipsController
            (
            NotAShopContext context
            )
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.Spaceships
                .Select(x => new SpaceshipsIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    BuiltDate = x.BuiltDate,
                    Crew = x.Crew,
                });

            return View(result);
        }

    }
}
