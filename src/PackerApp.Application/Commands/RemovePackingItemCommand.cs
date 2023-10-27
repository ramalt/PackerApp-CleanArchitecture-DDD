using PackerApp.Shared.Abstractions.Commands;

namespace PackerApp.Application.Commands;

public record RemovePackingItemCommand(Guid PackingListId, string Name) : ICommand;