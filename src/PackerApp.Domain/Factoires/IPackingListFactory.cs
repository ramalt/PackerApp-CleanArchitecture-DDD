using PackerApp.Domain.Entities;
using PackerApp.Domain.Enums;
using PackerApp.Domain.ValueObjects;

namespace PackerApp.Domain.Factoires;

public interface IPackingListFactory
{
    PackingList Create(PackingListId id, PackingListName name, Localization localization);
    PackingList CreateWithDefaultItems(PackingListId id, PackingListName name, Localization localization, TravelDays days, Gender gender, Temprature temprature);
}
