using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotAShop.Data;
using NotAShop.Models.Kindergartens;

namespace NotAShop.Controllers
{
    public class KindergartensController : Controller
    {
        private readonly NotAShopContext _context;
        public KindergartensController
            (
            NotAShopContext context
            )
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.Kindergartens
                .Select(x => new KindergartensIndexViewModel
                {
                    Id = x.Id,
                    GroupName = x.GroupName,
                    ChildrenCount = x.ChildrenCount,
                    KindergartenName = x.KindergartenName,
                    Teacher = x.Teacher,

                });
            return View(result);
        }
    }
}
