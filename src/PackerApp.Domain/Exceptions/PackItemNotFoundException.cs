using PackerApp.Shared.Abstractions.Exceptions;

namespace PackerApp.Domain.Exceptions;

public class PackItemNotFoundException : PackerAppException
{
    public string ItemName { get; }
    public PackItemNotFoundException(string itemName) : base($"Packing item '{itemName}' not found")
        => ItemName = itemName;
}
