using PackerApp.Shared.Abstractions.Exceptions;

namespace PackerApp.Domain.Exceptions;

public class EmptyPackingListIdException : PackerAppException
{
    public EmptyPackingListIdException() : base("Packing List Id cannot be empty")
    {
    }
}
