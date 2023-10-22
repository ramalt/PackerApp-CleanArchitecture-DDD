using PackerApp.Domain.Exceptions;

namespace PackerApp.Domain.ValueObjects;

public record PackingItem
{
    public string Name { get; init; }    
    public int Quantity { get; init; }    
    public bool IsPacked { get; init; }   

    public PackingItem(string name, int quantity, bool isPacked)
    {
        if(string.IsNullOrWhiteSpace(name))
            throw new EmptyPackingItemException();
            
        Name = name;
        Quantity = quantity;
        IsPacked = isPacked;
    } 
}
