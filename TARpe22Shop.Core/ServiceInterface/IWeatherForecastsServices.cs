using TARpe22ShopVäli.Core.Dto.WeatherDtos;

namespace TARpe22ShopVäli.ApplicationServices.Services
{
    public interface IWeatherForecastsServices
    {
        Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto);
    }
}