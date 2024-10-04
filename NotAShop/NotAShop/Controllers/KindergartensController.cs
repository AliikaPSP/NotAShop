using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotAShop.ApplicationServices.Services;
using NotAShop.Core.ServiceInterface;
using NotAShop.Data;
using NotAShop.Models.Kindergartens;

namespace NotAShop.Controllers
{
    public class KindergartensController : Controller
    {
        private readonly NotAShopContext _context;
        private readonly IKindergartensServices _kindergartensServices;
        public KindergartensController
            (
            NotAShopContext context,
            IKindergartensServices kindergartensServices
            )
        {
            _context = context;
            _kindergartensServices = kindergartensServices;
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
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var kindergarten = await _kindergartensServices.DetailAsync(id);

            if (kindergarten == null)
            {
                return NotFound();

            }

            var vm = new KindergartenDetailsViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;
            vm.KindergartenName = kindergarten.KindergartenName;
            vm.Teacher = kindergarten.Teacher;
            vm.CreatedAt = kindergarten.CreatedAt;
            vm.UpdatedAt = kindergarten.UpdatedAt;

            return View(vm);
        }
    }
}
