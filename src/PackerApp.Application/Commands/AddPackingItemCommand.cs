using PackerApp.Shared.Abstractions.Commands;

namespace PackerApp.Application.Commands;

public record AddPackingItemCommand(Guid PackingListId, string Name, int Quantity) : ICommand
{
}

