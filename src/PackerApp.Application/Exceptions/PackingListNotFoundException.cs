using PackerApp.Shared.Abstractions.Exceptions;

namespace PackerApp.Application.Exceptions;

public class PackingListNotFoundException : PackerAppException
{
    public PackingListNotFoundException(Guid id) : base($"Packing item not found with id: {id}")
    {
    }
}
