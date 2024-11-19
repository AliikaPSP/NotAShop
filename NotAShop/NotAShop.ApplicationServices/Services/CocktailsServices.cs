using NotAShop.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NotAShop.ApplicationServices.Services
{
    public class CocktailsServices
    {
        public async Task<List<CocktailsDto>> GetCocktailsAsync(CocktailsDto dto)
        {
            string cocktailApiKey = "1";
            string url = $"https://www.thecocktaildb.com/api/json/v1/1/search.php?apikey={cocktailApiKey}&q={dto.strDrink}";

            List<CocktailsDto> gamesList = new List<CocktailsDto>();

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                var freeGameResults = JsonSerializer.Deserialize<List<F2PGamesDto>>(json);
                if (freeGameResults != null)
                {
                    gamesList.AddRange(freeGameResults);
                }
            }
            return gamesList;
        }
    }
}
