using Microsoft.AspNetCore.Mvc;
using NotAShop.ApplicationServices.Services;
using NotAShop.Core.Dto;
using NotAShop.Core.ServiceInterface;
using NotAShop.Data;
using NotAShop.Models.RealEstates;

namespace NotAShop.Controllers
{
    public class RealEstatesController : Controller
    {
        private readonly NotAShopContext _context;
        private readonly IRealEstateServices _realEstateServices;
        public RealEstatesController
            (
            NotAShopContext context,
            IRealEstateServices realEstatesServices
            )
        {
            _context = context;
            _realEstateServices = realEstatesServices;
        }
        public IActionResult Index()
        {

            var result = _context.RealEstates
                .Select(x => new RealEstateIndexViewModel
                {
                    Id = x.Id,
                    Size = x.Size,
                    Location = x.Location,
                    RoomNumber = x.RoomNumber,
                    BuildingType = x.BuildingType,
                });
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            RealEstateCreateUpdateViewModel result = new RealEstateCreateUpdateViewModel();

            return View("CreateUpdate", result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Size = vm.Size,
                Location = vm.Location,
                RoomNumber = vm.RoomNumber,
                BuildingType = vm.BuildingType,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
            };

            var result = await _realEstateServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var realEstate = await _realEstateServices.GetAsync(id);

            if (realEstate == null)
            {
                return NotFound();
            }

            var vm = new RealEstateDetailsViewModel();

            vm.Id = realEstate.Id;
            vm.Size = realEstate.Size;
            vm.RoomNumber = realEstate.RoomNumber;
            vm.Location = realEstate.Location;
            vm.BuildingType = realEstate.BuildingType;
            vm.CreatedAt = realEstate.CreatedAt;
            vm.ModifiedAt = realEstate.ModifiedAt;

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var realEstate = await _realEstateServices.GetAsync(id);
            if (realEstate == null)
            {
                return NotFound();
            }
            var vm = new RealEstateCreateUpdateViewModel();
            vm.Id = realEstate.Id;
            vm.Size = realEstate.Size;
            vm.RoomNumber = realEstate.RoomNumber;
            vm.Location = realEstate.Location;
            vm.BuildingType = realEstate.BuildingType;
            vm.CreatedAt = realEstate.CreatedAt;
            vm.ModifiedAt = realEstate.ModifiedAt;
            return View("CreateUpdate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = vm.Id,
                Size = vm.Size,
                RoomNumber = vm.RoomNumber,
                Location = vm.Location,
                BuildingType = vm.BuildingType,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
            };
            var result = await _realEstateServices.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }
    }
}
