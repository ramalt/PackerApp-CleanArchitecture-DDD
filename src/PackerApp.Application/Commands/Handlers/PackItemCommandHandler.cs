using PackerApp.Application.Exceptions;
using PackerApp.Domain.Repositories;
using PackerApp.Shared.Abstractions.Commands;

namespace PackerApp.Application.Commands.Handlers;

internal sealed class PackItemHandler : ICommandHandler<PackItemCommand>
    {
        private readonly IPackingListRepository _repository;

        public PackItemHandler(IPackingListRepository repository)
            => _repository = repository;

        public async Task HandleAsync(PackItemCommand command)
        {
            var packingList = await _repository.GetAsync(command.PackingListId);

            if (packingList is null)
            {
                throw new PackingListNotFoundException(command.PackingListId);
            }
            
            packingList.PackItem(command.Name);
            
            await _repository.UpdateAsync(packingList);
        }
    }
