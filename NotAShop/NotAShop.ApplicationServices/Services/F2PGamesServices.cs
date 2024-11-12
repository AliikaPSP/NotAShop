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
    public class F2PGamesServices
    {
        public async Task<List<F2PGamesDto>> GetF2PGamesAsync()
        {
            string url = "https://www.freetogame.com/api/games";

            using (WebClient client = new WebClient())
            {
                string json = await client.DownloadStringTaskAsync(url);

                List<F2PGamesDto> gamesList = JsonSerializer.Deserialize<List<F2PGamesDto>>(json);

                return gamesList;
            }
        }
    }
}
