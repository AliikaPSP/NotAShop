using Microsoft.AspNetCore.Mvc;
using NotAShop.Core.Dto;
using NotAShop.Core.ServiceInterface;
using NotAShop.Models.ChuckNorris;

namespace NotAShop.Controllers
{
    public class ChuckNorrisController : Controller
    {
        private readonly IChuckNorrisServices _chuckNorrisServices;

        public ChuckNorrisController
            (
                IChuckNorrisServices chuckNorrisServices
            )
        {
            _chuckNorrisServices = chuckNorrisServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SearchJoke()
        {
            var jokeDto = new ChuckNorrisDto();
      
            var joke = await _chuckNorrisServices.GetRandomJokeAsync(jokeDto);

            var jokeViewModel = new ChuckNorrisIndexViewModel
            {
                JokeValue = joke.Value,
                JokeIconUrl = joke.IconUrl,
                JokeId = joke.Id
            };

            return View("Index", jokeViewModel);
        }
    }
}
