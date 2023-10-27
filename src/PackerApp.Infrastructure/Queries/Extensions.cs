using PackerApp.Application.Dtos;
using PackerApp.Application.Dtos.PackingList;
using PackerApp.Domain.ValueObjects;
using PackerApp.Infrastructure.EFCore.Models;

namespace PackerApp.Infrastructure.Queries;

public static class Extensions
{
    public static PackingListDto toDto(this PackingListReadModel readModel)
    {
        return new()
        {
            Id = readModel.Id,
            Name = readModel.Name,
            Localization = new LocalizationDto()
            {
                City = readModel.Localization.City,
                Country = readModel.Localization.Country,
            },
            Items = readModel.Items.Select(
                i =>
                    new PackingItemDto()
                    {
                        Name = i.Name,
                        Quantity = i.Quantity,
                        IsPacked = i.IsPacked
                    }
            )
        };
    }
}
