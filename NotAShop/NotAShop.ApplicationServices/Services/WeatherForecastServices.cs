
using Nancy.Json;
using NotAShop.Core.Dto.WeatherDtos.AccuWeatherDtos;
using NotAShop.Core.ServiceInterface;
using System.Net;
using System.Text.Json;

namespace NotAShop.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {
        public async Task<AccuLocationWeatherResultDto> AccuWeatherResult(AccuLocationWeatherResultDto dto)
        {
            string accuApiKey = "S20Ney8kSamAMS3pP3Ad1hPY95EpehS0";
            string url = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={accuApiKey}&q={dto.CityName}";

            //Sordib välja city koodi-tulemus linna kood
            using (WebClient client = new WebClient()) 
            {
                string json = client.DownloadString(url);
                //127964
                List<AccuLocationRootDto> accuResult = new JavaScriptSerializer().Deserialize<List<AccuLocationRootDto>>(json);

                dto.CityName = accuResult[0].LocalizedName;
                dto.CityCode = accuResult[0].Key;
            }

            string urlWeather = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{dto.CityCode}?apikey={accuApiKey}&metric=true";

            //citykoodi järgi mis ilm linnas-tulemus ilmateade
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(urlWeather);
                AccuWeatherRootDto weatherRootDto = new JavaScriptSerializer().Deserialize<AccuWeatherRootDto>(json);

                dto.EffectiveDate = weatherRootDto.Headline.EffectiveDate.ToString("yyyy-MM-dd");
                dto.EffectiveEpochDate = weatherRootDto.Headline.EffectiveEpochDate;
                dto.Severity = weatherRootDto.Headline.Severity;
                dto.Text = weatherRootDto.Headline.Text;
                dto.Category = weatherRootDto.Headline.Category;
                dto.EndDate = weatherRootDto.Headline.EndDate.ToString("yyyy-MM-dd");
                dto.EndEpochDate = weatherRootDto.Headline.EndEpochDate;

                dto.MobileLink = weatherRootDto.Headline.MobileLink;
                dto.Link = weatherRootDto.Headline.Link;

                var dailyForecasts = weatherRootDto.DailyForecasts[0];

                dto.DailyForecastsDate = dailyForecasts.Date.ToString("yyyy-MM-dd");
                dto.DailyForecastsEpochDate = dailyForecasts.EpochDate;
                dto.TempMinValue = dailyForecasts.Temperature.Minimum.Value;
                dto.TempMinUnit = dailyForecasts.Temperature.Minimum.Unit;
                dto.TempMinUnitType = dailyForecasts.Temperature.Minimum.UnitType;

                dto.TempMaxValue = dailyForecasts.Temperature.Maximum.Value;
                dto.TempMaxUnit = dailyForecasts.Temperature.Maximum.Unit;
                dto.TempMaxUnitType = dailyForecasts.Temperature.Maximum.UnitType;


                dto.DayIcon = dailyForecasts.Day.Icon;
                dto.DayIconPhrase = dailyForecasts.Day.IconPhrase;
                dto.DayHasPrecipitation = dailyForecasts.Day.HasPrecipitation;
                dto.DayPrecipitationType = dailyForecasts.Day.PrecipitationType;
                dto.DayPrecipitationIntensity = dailyForecasts.Day.PrecipitationIntensity;

                dto.NightIcon = dailyForecasts.Night.Icon;
                dto.NightIconPhrase = dailyForecasts.Night.IconPhrase;
                dto.NightHasPrecipitation = dailyForecasts.Night.HasPrecipitation;
                dto.NightPrecipitationType = dailyForecasts.Night.PrecipitationType;
                dto.NightPrecipitationIntensity = dailyForecasts.Night.PrecipitationIntensity;

            }

            return dto;
        }
    }
}
