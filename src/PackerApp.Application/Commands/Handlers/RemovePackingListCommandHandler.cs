using PackerApp.Application.Exceptions;
using PackerApp.Domain.Repositories;
using PackerApp.Shared.Abstractions.Commands;

namespace PackerApp.Application.Commands.Handlers;

internal sealed class RemovePackingListHandler : ICommandHandler<RemovePackingListCommand>
    {
        private readonly IPackingListRepository _repository;

        public RemovePackingListHandler(IPackingListRepository repository)
            => _repository = repository;

        public async Task HandleAsync(RemovePackingListCommand command)
        {
            var packingList = await _repository.GetAsync(command.Id);

            if (packingList is null)
            {
                throw new PackingListNotFoundException(command.Id);
            }

            await _repository.DeleteAsync(packingList);
        }
    }

