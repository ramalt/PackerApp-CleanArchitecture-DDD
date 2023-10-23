using PackerApp.Domain.ValueObjects;
using PackerApp.Shared.Abstractions.Exceptions;

namespace PackerApp.Application.Exceptions;

public class MissingLocalizationWeatherException : PackerAppException
{
    public Localization Localization { get; }
    public MissingLocalizationWeatherException(Localization localization) : base($"Could not fetch weather data for '{localization.City}/{localization.Country.ToUpper()}'")
        => Localization = localization;
}
