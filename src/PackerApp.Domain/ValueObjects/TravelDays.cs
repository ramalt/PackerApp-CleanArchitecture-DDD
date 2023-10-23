using PackerApp.Domain.Exceptions;

namespace PackerApp.Domain.ValueObjects;

public record TravelDays
{
    public int Value { get; init; }
    public TravelDays(int value)
    {
        if (value is 0 or > 100)
        {
            throw new PackingItemTravelDayOverLimitException(value);
        }   

        Value = value;
    }

    public static implicit operator int(TravelDays day) => day.Value;
    public static implicit operator TravelDays(int day) => new(day);
}
