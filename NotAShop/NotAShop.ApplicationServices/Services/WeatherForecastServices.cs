
using Nancy.Json;
using NotAShop.Core.Dto.WeatherDtos.AccuWeatherDtos;
using System.Net;

namespace NotAShop.ApplicationServices.Services
{
    public class WeatherForecastServices
    {
        public async Task<AccuLocationWeatherResultDto> AccuWeatherResult(AccuLocationWeatherResultDto dto)
        {
            string accuApiKey = "S20Ney8kSamAMS3pP3Ad1hPY95EpehS0";
            string url = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={accuApiKey}&q={dto.CityName}";

            using (WebClient client = new WebClient()) 
            {
                string json = client.DownloadString(url);
                AccuLocationRootDto accuResult = new JavaScriptSerializer().Deserialize<AccuLocationRootDto>(json);
            }

            return dto;
        }
    }
}
