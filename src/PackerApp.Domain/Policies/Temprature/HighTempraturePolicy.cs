using PackerApp.Domain.ValueObjects;

namespace PackerApp.Domain.Policies.Temprature;

public class HighTempraturePolicy : IPackingItemPolicy
{
    public IEnumerable<PackingItem> GenerateItems(PolicyData data)
        => new List<PackingItem>{
            new("Sunscreen", 1),
            new("Hat", 1),
            new("Flip Flop", 1),
            new("Bottled water", 23),
        };

    public bool IsAcceptable(PolicyData data) => data.Temprature > 25D;
}
