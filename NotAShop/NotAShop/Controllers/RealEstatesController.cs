using Microsoft.AspNetCore.Mvc;
using NotAShop.ApplicationServices.Services;
using NotAShop.Core.ServiceInterface;
using NotAShop.Data;
using NotAShop.Models.RealEstates;
using NotAShop.Models.Spaceships;

namespace NotAShop.Controllers
{
    public class RealEstatesController : Controller
    {
        private readonly NotAShopContext _context;
        private readonly IRealEstateServices _realestateServices;
        public RealEstatesController
            (
            NotAShopContext context,
            IRealEstateServices realEstatesServices
            )
        {
            _context = context;
            _realestateServices = realEstatesServices;
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
            return View();
        }
    }
}
