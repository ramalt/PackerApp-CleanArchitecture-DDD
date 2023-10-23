using PackerApp.Shared.Abstractions.Exceptions;

namespace PackerApp.Domain.Exceptions;

public class TempratureOverLimitException : PackerAppException
{
    public double Value { get; }
    public TempratureOverLimitException(double temprature) : base($"Invalid value for temprature: '{temprature}'. 'temprature' value must be greater than -100 and less than 100 degree.")
        => Value = temprature;
}
