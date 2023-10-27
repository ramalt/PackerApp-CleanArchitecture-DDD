using PackerApp.Application.Exceptions;
using PackerApp.Domain.Repositories;
using PackerApp.Shared.Abstractions.Commands;

namespace PackerApp.Application.Commands.Handlers;

internal sealed class RemovePackingItemHandler : ICommandHandler<RemovePackingItemCommand>
    {
        private readonly IPackingListRepository _repository;

        public RemovePackingItemHandler(IPackingListRepository repository)
            => _repository = repository;

        public async Task HandleAsync(RemovePackingItemCommand command)
        {
            var packingList = await _repository.GetAsync(command.PackingListId);

            if (packingList is null)
            {
                throw new PackingListNotFoundException(command.PackingListId);
            }

            packingList.RemoveItem(command.Name);

            await _repository.UpdateAsync(packingList);
        }
    }