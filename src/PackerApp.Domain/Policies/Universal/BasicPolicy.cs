using PackerApp.Domain.ValueObjects;

namespace PackerApp.Domain.Policies.Universal;

public class BasicPolicy : IPackingItemPolicy
{
    public IEnumerable<PackingItem> GenerateItems(PolicyData data)
         => new List<PackingItem>
            {
                new("Pants", 7),
                new("Socks", 7),
                new("T-Shirt", 7),
                new("Trousers", 7),
                new("Shampoo", 1),
                new("Toothbrush", 1),
                new("Toothpaste", 1),
                new("Towel", 1),
                new("Bag pack", 1),
                new("Passport", 1),
                new("Phone Charger", 1)
            }; 

    public bool IsAcceptable(PolicyData data) => true;
}
