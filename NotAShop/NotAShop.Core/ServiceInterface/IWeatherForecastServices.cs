using NotAShop.Core.Dto.WeatherDtos.AccuWeatherDtos;

namespace NotAShop.Core.ServiceInterface
{
    public interface IWeatherForecastServices
    {
        Task<AccuLocationWeatherResultDto> AccuWeatherResult(AccuLocationWeatherResultDto dto);
    }
}
