using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotAShop.ApplicationServices.Services;
using NotAShop.Core.ServiceInterface;
using NotAShop.Data;
using NotAShop.Models.Kindergartens;
using NotAShop.Core.Dto;
using static System.Net.Mime.MediaTypeNames;

namespace NotAShop.Controllers
{
    public class KindergartensController : Controller
    {
        private readonly NotAShopContext _context;
        private readonly IKindergartensServices _kindergartensServices;
        private readonly IFileServices _fileServices;
        public KindergartensController
            (
            NotAShopContext context,
            IKindergartensServices kindergartensServices,
            IFileServices fileServices
            )
        {
            _context = context;
            _kindergartensServices = kindergartensServices;
            _fileServices = fileServices;
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

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var kindergarten = await _kindergartensServices.DetailAsync(id);

            if (kindergarten == null)
            {
                return NotFound();
            }

            var vm = new KindergartenCreateUpdateViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;
            vm.KindergartenName = kindergarten.KindergartenName;
            vm.Teacher = kindergarten.Teacher;
            vm.CreatedAt = kindergarten.CreatedAt;
            vm.UpdatedAt = kindergarten.UpdatedAt;

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(KindergartenCreateUpdateViewModel vm)
        {
            var dto = new KindergartenDto()
            {
                Id = vm.Id,
                GroupName = vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KindergartenName = vm.KindergartenName,
                Teacher = vm.Teacher,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt
            };

            var result = await _kindergartensServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var kindergarten = await _kindergartensServices.DetailAsync(id);

            if (kindergarten == null)
            {
                return NotFound();
            }

            var vm = new KindergartenDeleteViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;
            vm.KindergartenName = kindergarten.KindergartenName;
            vm.Teacher = kindergarten.Teacher;
            vm.CreatedAt = kindergarten.CreatedAt;
            vm.UpdatedAt = kindergarten.UpdatedAt;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var kindergarten = await _kindergartensServices.Delete(id);

            if (kindergarten == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Create()
        {
            KindergartenCreateUpdateViewModel result = new KindergartenCreateUpdateViewModel();

            return View("CreateUpdate", result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(KindergartenCreateUpdateViewModel vm)
        {
            var dto = new KindergartenDto()
            {
                Id = vm.Id,
                GroupName = vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KindergartenName = vm.KindergartenName,
                Teacher = vm.Teacher,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,
                Files = vm.Files,
                Image = vm.Image
                    .Select(x => new ImageToDatabaseDto
                    {
                        Id = x.ImageId,
                        ImageData = x.ImageData,
                        ImageTitle = x.ImageTitle,
                        KindergartenId = x.KindergartenId
                    }).ToArray()
            };

            var result = await _kindergartensServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
