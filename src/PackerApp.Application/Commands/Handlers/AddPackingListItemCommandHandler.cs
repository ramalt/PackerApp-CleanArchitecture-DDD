using PackerApp.Application.Exceptions;
using PackerApp.Domain.Repositories;
using PackerApp.Domain.ValueObjects;
using PackerApp.Shared.Abstractions.Commands;

namespace PackerApp.Application.Commands.Handlers;

public class AddPackingListItemCommandHandler : ICommandHandler<AddPackingItemCommand>
{
    private readonly IPackingListRepository _repository;

    public AddPackingListItemCommandHandler(IPackingListRepository repository) => _repository = repository;

    public async Task HandleAsync(AddPackingItemCommand command)
    {
        var packingList = await _repository.GetAsync(command.PackingListId);

        if (packingList is null)
        {
            throw new PackingListNotFoundException(command.PackingListId);
        }

        var packingItem = new PackingItem(command.Name, command.Quantity);
        packingList.AddItem(packingItem);

        await _repository.UpdateAsync(packingList);
    }
}
