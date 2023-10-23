using PackerApp.Domain.Entities;
using PackerApp.Domain.Enums;
using PackerApp.Domain.Policies;
using PackerApp.Domain.ValueObjects;

namespace PackerApp.Domain.Factoires;

public class PackingListFactory : IPackingListFactory
{
    private readonly IEnumerable<IPackingItemPolicy> _policies;

    public PackingListFactory(IEnumerable<IPackingItemPolicy> policies)
        => _policies = policies;

    /*
        Manually create a packing list
    */
    public PackingList Create(PackingListId id, PackingListName name, Localization localization)
        => new PackingList(id, name, localization);

    /*
        Create with custom settings
    */
    public PackingList CreateWithDefaultItems(PackingListId id, PackingListName name, Localization localization, TravelDays days, Gender gender, Temprature temprature)
    {
        var data = new PolicyData(days, gender, temprature, localization);

        var validPolicies = _policies.Where(p => p.IsAcceptable(data)); // Get applicable policies with given policy data

        var generatedPackingItemsWithPolicies = validPolicies.SelectMany(v => v.GenerateItems(data)); // generate items for valid policies

        var newPackingList = Create(id, name, localization);

        newPackingList.AddItems(generatedPackingItemsWithPolicies); // add created packing items to packing list

        return newPackingList;

    }
}
