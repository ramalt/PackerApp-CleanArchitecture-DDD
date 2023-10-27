using PackerApp.Shared.Abstractions.Commands;

namespace PackerApp.Application.Commands;

public record PackItemCommand(Guid PackingListId, string Name) : ICommand;
