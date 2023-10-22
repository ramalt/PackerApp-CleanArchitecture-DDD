using PackerApp.Shared.Abstractions.Exceptions;

namespace PackerApp.Domain.Exceptions;

public class EmptyPackingItemException : PackerAppException
{
    public EmptyPackingItemException() : base("Packing item name is empty.")
    {
    }
}
