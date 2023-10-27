using PackerApp.Domain.Events;
using PackerApp.Domain.Exceptions;
using PackerApp.Domain.ValueObjects;
using PackerApp.Shared.Abstractions.Domain;

namespace PackerApp.Domain.Entities;

public class PackingList : AggregateRoot<PackingListId>
{
    public PackingListId Id { get; }
    private PackingListName _name;
    private Localization _localization;
    private readonly List<PackingItem> _items = new();
    private PackingList(){}
    public PackingList(Guid id, PackingListName name, Localization localization)
    {
        Id = id;
        _name = name;
        _localization = localization;
    }
    private PackingList(Guid id, PackingListName name, Localization localization, List<PackingItem> items) : this(id, name, localization)
    {
        _items = items;
    }
    public void AddItem(PackingItem item)
    {
        var exist = _items.Any(i => i.Name == item.Name);

        if (exist)
            throw new PackingItemAlreadyExistException(nameof(_items), item.Name);

        _items.Add(item);
        AddEvent(new PackingItemAdded(this, item));
    }
    public void AddItems(IEnumerable<PackingItem> items)
    {
        foreach (var item in items)
        {
            AddItem(item);
        }
    }
    public void PackItem(string name)
    {
        PackingItem? item = GetItem(name);

        var packedItem = item with { IsPacked = true };

        _items[_items.IndexOf(item)] = packedItem; // ? _items.Find(item).Value 
        AddEvent(new PackingItemPacked(this, item));
    }
    public void RemoveItem(string name)
    {
        PackingItem? item = GetItem(name);

        _items.Remove(item); // ? _items.Find(item).Value 
        AddEvent(new PackingItemRemoved(this, item));
    }
    private PackingItem GetItem(string name)
    {
        var item = _items.SingleOrDefault(i => i.Name == name);
        if (item is null)
            throw new PackItemNotFoundException(name);

        return item;
    }
}
