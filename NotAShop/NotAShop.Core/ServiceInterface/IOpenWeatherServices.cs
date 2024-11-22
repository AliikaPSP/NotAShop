using NotAShop.Core.Dto.WeatherDtos.OpenWeatherDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotAShop.Core.ServiceInterface
{
    public interface IOpenWeatherServices
    {
        public Task<OpenWeatherResultDto> OpenWeatherResult(OpenWeatherResultDto dto);
    }
}
