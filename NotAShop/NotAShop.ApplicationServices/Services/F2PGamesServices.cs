using Nancy.Json;
using NotAShop.Core.Dto;
using NotAShop.Core.ServiceInterface;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NotAShop.ApplicationServices.Services
{
    public class F2PGamesServices : IF2PGamesServices
    {
        public async Task<F2PGamesDto> GetF2PGamesAsync(F2PGamesDto[] dto)
        {
            string url = "https://www.freetogame.com/api/games";

            using (WebClient client = new WebClient())
            {
                string json = await client.DownloadStringTaskAsync(url);

                List<F2PGamesDto> gamesList = new JavaScriptSerializer().Deserialize<List<F2PGamesDto>>(json);
                //.javascriptserializer().Deserialize

                return gamesList;
            }
        }
    }
}
