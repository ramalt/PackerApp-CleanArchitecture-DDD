using PackerApp.Domain.ValueObjects;

namespace PackerApp.Domain.Policies;

public record PolicyData(TravelDays Days, Enums.Gender Gender, ValueObjects.Temprature Temprature, Localization Localization)
{
    
}