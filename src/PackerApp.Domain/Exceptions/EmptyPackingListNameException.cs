using PackerApp.Shared.Abstractions.Exceptions;

namespace PackerApp.Domain.Exceptions;

public class EmptyPackingListNameException : PackerAppException
{
    public EmptyPackingListNameException() : base("packing list name is empty")
    {
    }
}
