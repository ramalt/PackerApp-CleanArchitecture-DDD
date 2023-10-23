using PackerApp.Shared.Abstractions.Exceptions;

namespace PackerApp.Domain.Exceptions;

public class PackingItemTravelDayOverLimitException : PackerAppException
{
    public PackingItemTravelDayOverLimitException(int day) : base($"Invalid value for packing item travel days: '{day}'. 'day' value must be greater than 0 and less than 100 day.")
    {
    }
}
