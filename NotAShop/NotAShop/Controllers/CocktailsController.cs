using Microsoft.AspNetCore.Mvc;
using NotAShop.Core.Dto;
using NotAShop.Core.ServiceInterface;
using NotAShop.Models.Cocktails;

namespace NotAShop.Controllers
{
    public class CocktailsController : Controller
    {
        private readonly ICocktailsServices _cocktailsServices;
        public CocktailsController(ICocktailsServices cocktailsServices)
        {
            _cocktailsServices = cocktailsServices;
        }

        // Controller actions
        public async Task<IActionResult> Index(string drinkName)
        {
            var viewModel = new CocktailsIndexViewModel();

            if (!string.IsNullOrEmpty(drinkName))
            {
                var dto = new CocktailsDto { strDrink = drinkName };
                viewModel.Cocktails = await _cocktailsServices.GetCocktailsAsync(dto);
            }

            return View(viewModel);
        }
    }
}
