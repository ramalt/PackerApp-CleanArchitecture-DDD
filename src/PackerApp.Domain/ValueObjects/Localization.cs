namespace PackerApp.Domain.ValueObjects;

public record Localization(string City, string Country)
{
    // string -> object casting
    public static Localization Create(string value)
    {
        var splitLocalization = value.Split(',');
        return new(splitLocalization.First(), splitLocalization.Last());
    }

    // object -> string casting
    public override string ToString()
    {
        return $"{City},{Country}";
    }
}
