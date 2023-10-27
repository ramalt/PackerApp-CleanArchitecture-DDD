using PackerApp.Shared.Abstractions.Commands;

namespace PackerApp.Application.Commands;

public record RemovePackingListCommand(Guid Id) : ICommand;
