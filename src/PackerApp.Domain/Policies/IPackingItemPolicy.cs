using PackerApp.Domain.ValueObjects;

namespace PackerApp.Domain.Policies;

public interface IPackingItemPolicy
{
    bool IsAcceptable(PolicyData data);
    IEnumerable<PackingItem> GenerateItems(PolicyData data);
}
