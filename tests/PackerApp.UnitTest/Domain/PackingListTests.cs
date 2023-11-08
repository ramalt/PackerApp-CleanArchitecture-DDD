using PackerApp.Domain.Entities;
using PackerApp.Domain.Events;
using PackerApp.Domain.Exceptions;
using PackerApp.Domain.Factoires;
using PackerApp.Domain.Policies;
using PackerApp.Domain.ValueObjects;
using Shouldly;

namespace PackerApp.UnitTest.Domain;

public class PackingListTests
{
    private readonly IPackingListFactory _factory;
    public PackingListTests() => _factory = new PackingListFactory(Enumerable.Empty<IPackingItemPolicy>());

    private PackingList GetPackingList()
    {
        var packingList = _factory.Create(Guid.NewGuid(), "New Packing List", Localization.Create("Ankara, TURKEY"));
        packingList.ClearEvents();
        return packingList;
    }

    [Fact]
    public void AddItem_Throws_PackingItemAlreadyExistException_When_There_Is_Already_Item_With_Name()
    {
        var packingList = GetPackingList();

        packingList.AddItem(new PackingItem("Item 1", 1));

        var exception = Record.Exception(() => packingList.AddItem(new PackingItem("Item 1", 1)));

        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<PackingItemAlreadyExistException>();

    }

    public void AddItem_Adds_PackingItemAdded_Domain_Event_On_Success()
    {
        var packingList = GetPackingList();

        var exception = Record.Exception(() => packingList.AddItem(new PackingItem("Item 1", 1)));

        exception.ShouldBeNull();
        packingList.Events.Count().ShouldBe(1);

        var @event = packingList.Events.FirstOrDefault() as PackingItemAdded;

        @event.ShouldNotBeNull();
        @event.PackingItem.Name.ShouldBe("Item 1");
    }

}
