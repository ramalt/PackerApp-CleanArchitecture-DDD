using PackerApp.Domain.ValueObjects;

namespace PackerApp.Domain.Policies.Gender;

public class FemaleGenderPolicy : IPackingItemPolicy
{
    public IEnumerable<PackingItem> GenerateItems(PolicyData data) 
        => new List<PackingItem>{
            new("Foundation Cream", 1),
            new("Lipstick", 1),
            new("Eyeliner", 1),
            new("Skinfood", 1),
            new("Blusher", 2)
            };

    public bool IsAcceptable(PolicyData data) => data.Gender == Enums.Gender.Female;
}
