using ValiShop.Core.Dto.WeatherDtos;

namespace ValiShop.ApplicationServices.Services
{
    public interface IWeatherForecastsServices
    {
        Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto);
    }
}