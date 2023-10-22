using PackerApp.Domain.Exceptions;

namespace PackerApp.Domain.ValueObjects;

public record PackingListName
{
    public string Value { get; }    

    public PackingListName(string value) {

        if(string.IsNullOrWhiteSpace(value))
            throw new EmptyPackingListNameException();

        Value = value;
    }

    // string <-> PackingListName Casting by "implicit operator"
    public static implicit operator string(PackingListName name) => name.Value;
    public static implicit operator PackingListName(string name) => new(name);
}
