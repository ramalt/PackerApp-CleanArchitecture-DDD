using PackerApp.Application.Dtos;
using PackerApp.Application.Services;
using PackerApp.Domain.ValueObjects;

namespace PackerApp.Infrastructure.Services;

public class DumbWeatherService : IWeatherService
{
    public Task<WeatherDto> GetWeatherAsync(Localization localization) =>
        Task.FromResult(new WeatherDto(new Random().Next(5, 30)));
}
