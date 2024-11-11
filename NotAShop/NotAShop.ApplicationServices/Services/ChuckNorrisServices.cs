using NotAShop.Core.Dto;
using NotAShop.Core.ServiceInterface;
using System.Net;
using System.Threading.Tasks;
using System.Text.Json;

namespace NotAShop.ApplicationServices.Services
{
    public class ChuckNorrisServices : IChuckNorrisServices
    {
        public async Task<ChuckNorrisDto> GetRandomJokeAsync(ChuckNorrisDto dto)
        {
            string url = "https://api.chucknorris.io/jokes/random";

            using (WebClient client = new WebClient())
            {
                string json = await client.DownloadStringTaskAsync(url);

                ChuckNorrisDto jokeDto = JsonSerializer.Deserialize<ChuckNorrisDto>(json);

                return jokeDto;
            }
        }
    }
}
