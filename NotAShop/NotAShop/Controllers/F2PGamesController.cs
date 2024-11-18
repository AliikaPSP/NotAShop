using Microsoft.AspNetCore.Mvc;
using NotAShop.ApplicationServices.Services;
using NotAShop.Models.F2PGames;
using NotAShop.Core.ServiceInterface;
using NotAShop.Core.Dto;
using System.Linq;

namespace NotAShop.Controllers
{
    public class F2PGamesController : Controller
    {
        private readonly IF2PGamesServices _f2pGamesServices;

        public F2PGamesController(IF2PGamesServices f2pGamesServices)
        {
            _f2pGamesServices = f2pGamesServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var gameDto = new F2PGamesDto();
            var gamesDto = await _f2pGamesServices.GetF2PGamesAsync();
            var gamesViewModel = gamesDto.Select(g => new F2PGamesIndexViewModel
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

            if (gamesViewModel == null || !gamesViewModel.Any())
            {
                Console.WriteLine("No games found after mapping.");
            }

            var model = new F2PGamesIndexViewModel { Games = gamesViewModel };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SearchGames(F2PGamesIndexViewModel model)
        {
            // Get all games (you can add your filter logic here to optimize if needed)
            var games = await _f2pGamesServices.GetF2PGamesAsync();

            // Apply search filtering based on the user's search term
            if (!string.IsNullOrEmpty(model.SearchTerm))
            {
                games = games.Where(g => g.Title.Contains(model.SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                                          g.Genre.Contains(model.SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                                          g.Platform.Contains(model.SearchTerm, StringComparison.OrdinalIgnoreCase))
                             .ToList();
            }

            // Map filtered games to view model
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
                SearchTerm = model.SearchTerm
            };

            return View("Index", viewModel);
        }
    }
}
