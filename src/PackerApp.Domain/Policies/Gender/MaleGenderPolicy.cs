using PackerApp.Domain.ValueObjects;

namespace PackerApp.Domain.Policies.Gender;

public class MaleGenderPolicy : IPackingItemPolicy
{
    public IEnumerable<PackingItem> GenerateItems(PolicyData data) 
        => new List<PackingItem>{
            new("Laptop", 1),
            new("Spare shoes", 2, true),
            new("perfume", 1),
            new("Shaver", 1),
        };

    public bool IsAcceptable(PolicyData data) => data.Gender == Enums.Gender.Male;
}
