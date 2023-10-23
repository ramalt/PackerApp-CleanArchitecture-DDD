using PackerApp.Domain.Enums;
using PackerApp.Shared.Abstractions.Commands;

namespace PackerApp.Application.Commands;

public record CreatePackingListWithItemsCommand(Guid Id, string Name, int Days, Gender Gender, LocalizationWriteModel Localization) : ICommand
{
    
}

public record LocalizationWriteModel(string City, string Country);