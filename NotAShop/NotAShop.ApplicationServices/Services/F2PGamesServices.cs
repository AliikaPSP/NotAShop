using NotAShop.Core.Dto;
using NotAShop.Core.ServiceInterface;
using System.Net;
using System.Text.Json;

namespace NotAShop.ApplicationServices.Services
{
    public class F2PGamesServices : IF2PGamesServices
    {
        public async Task<List<F2PGamesDto>> GetF2PGamesAsync()
        {
            string url = "https://www.freetogame.com/api/games";
            List<F2PGamesDto> gamesList = new List<F2PGamesDto>();

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
