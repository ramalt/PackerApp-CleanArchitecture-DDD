using PackerApp.Domain.Exceptions;

namespace PackerApp.Domain.ValueObjects;

public record Temprature
{
    public double Value { get; init; }

    public Temprature(double temprature)
    {
        if (temprature is < -100 or > 100)
        {
            throw new TempratureOverLimitException(temprature);
        }

        Value = temprature;
    }

    public static implicit operator double(Temprature temprature) => temprature.Value;
    public static implicit operator Temprature(double temprature) => new(temprature);
}
