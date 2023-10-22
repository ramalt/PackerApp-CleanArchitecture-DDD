using PackerApp.Shared.Abstractions.Exceptions;

namespace PackerApp.Domain.Exceptions;

public class PackingItemAlreadyExistException : PackerAppException
{
    public PackingItemAlreadyExistException(string listName, string itemName) : base($"'{listName}' already has item '{itemName}'")
    {
    }
}
