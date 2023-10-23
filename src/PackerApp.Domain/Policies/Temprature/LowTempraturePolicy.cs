using PackerApp.Domain.ValueObjects;

namespace PackerApp.Domain.Policies.Temprature;

public class LowTempraturePolicy : IPackingItemPolicy
{
    public IEnumerable<PackingItem> GenerateItems(PolicyData data)
        => new List<PackingItem>{
            new("Gloves", 1),
            new("Boots", 1),
            new("coat", 1),
            new("balaclava", 2),
        };

    public bool IsAcceptable(PolicyData data) => data.Temprature < 0;
}
