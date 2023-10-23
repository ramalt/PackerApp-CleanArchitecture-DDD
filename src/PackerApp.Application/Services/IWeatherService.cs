using PackerApp.Application.Dtos;
using PackerApp.Domain.ValueObjects;

namespace PackerApp.Application.Services;

public interface IWeatherService
{
    Task<WeatherDto> GetWeatherAsync(Localization localization);
}
