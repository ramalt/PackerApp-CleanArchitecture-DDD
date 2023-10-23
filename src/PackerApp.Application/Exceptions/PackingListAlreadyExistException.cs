using PackerApp.Shared.Abstractions.Exceptions;

namespace PackerApp.Application.Exceptions;

public class PackingListAlreadyExistException : PackerAppException
{
    public string Name { get;}
    public PackingListAlreadyExistException(string name) : base($"Packing list already exist with name '{name}'")
        => Name = name;
}
