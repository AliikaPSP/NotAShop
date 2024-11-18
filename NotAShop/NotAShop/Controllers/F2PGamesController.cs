using Microsoft.AspNetCore.Mvc;
using NotAShop.ApplicationServices.Services;
using NotAShop.Models.F2PGames;
using NotAShop.Core.ServiceInterface;
using NotAShop.Core.Dto;

namespace NotAShop.Controllers
{
    public class F2PGamesController : Controller
    {
        private readonly F2PGamesServices _f2pGamesServices;

        public F2PGamesController(F2PGamesServices f2pGamesServices)
        {
            _f2pGamesServices = f2pGamesServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Load all games when the page is first loaded
            var gameDto = new F2PGamesDto();

            var games = await _f2pGamesServices.GetF2PGamesAsync(gameDto);
            var model = games.Select(g => new F2PGamesIndexViewModel
            {
                Id = g.Id,
                Title = g.Title,
                Thumbnail = g.Thumbnail,
                ShortDescription = g.ShortDescription,
                GameUrl = g.GameUrl,
                Genre = g.Genre,
                Platform = g.Platform,
                Publisher = g.Publisher,
                Developer = g.Developer,
                ReleaseDate = g.ReleaseDate,
                FreetogameProfileUrl = g.FreetogameProfileUrl
            }).ToList();

            return View(new F2PGamesIndexViewModel { Games = model });
        }

        [HttpPost]
        public async Task<IActionResult> SearchGames(F2PGamesIndexViewModel model)
        {
            var gameDto = new F2PGamesDto();

            // Get all F2P games
            var games = await _f2pGamesServices.GetF2PGamesAsync(gameDto);

            // If there is a search term, filter the games
            if (!string.IsNullOrEmpty(model.SearchTerm))
            {
                games = games.Where(g => g.Title.Contains(model.SearchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Map filtered games to F2PGamesIndexViewModel
            var viewModel = new F2PGamesIndexViewModel
            {
                Games = games.Select(g => new F2PGamesIndexViewModel
                {
                    Id = g.Id,
                    Title = g.Title,
                    Thumbnail = g.Thumbnail,
                    ShortDescription = g.ShortDescription,
                    GameUrl = g.GameUrl,
                    Genre = g.Genre,
                    Platform = g.Platform,
                    Publisher = g.Publisher,
                    Developer = g.Developer,
                    ReleaseDate = g.ReleaseDate,
                    FreetogameProfileUrl = g.FreetogameProfileUrl
                }).ToList(),
                SearchTerm = model.SearchTerm // Pass the search term to the view
            };

            return View("Index", viewModel);
        }
    }
}
