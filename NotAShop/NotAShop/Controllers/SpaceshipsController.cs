using Microsoft.AspNetCore.Mvc;
using NotAShop.Core.ServiceInterface;
using NotAShop.Data;
using NotAShop.Models.Spaceships;
using System.Runtime.Intrinsics.X86;

namespace NotAShop.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly NotAShopContext _context;
        private readonly ISpaceshipsServices _spaceshipServices;
        public SpaceshipsController
            (
            NotAShopContext context,
            ISpaceshipsServices spaceshipsServices
            )
        {
            _context = context;
            _spaceshipServices = spaceshipsServices;
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

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var spaceship = await _spaceshipServices.DetailAsync(id);
            if (spaceship == null)
            {
                return View("Error"); 
            }
            var vm = new SpaceshipDetailsViewModel();

            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.Type = spaceship.Type;
            vm.BuiltDate = spaceship.BuiltDate;
            vm.Crew = spaceship.Crew;
            vm.EnginePower = spaceship.EnginePower;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.ModifiedAt = spaceship.ModifiedAt;
            vm.SpaceshipModel = spaceship.SpaceshipModel;

            return View(vm);
                
        }
    }
}
