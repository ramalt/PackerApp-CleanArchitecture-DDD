using Microsoft.Extensions.DependencyInjection;
using PackerApp.Shared.Abstractions.Commands;

namespace PackerApp.Shared.Commands;

public class InMemoryCommandDiscpatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public InMemoryCommandDiscpatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    async Task ICommandDispatcher.DispatchAsync<TCommand>(TCommand command)
    {
        using var scope = _serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();

        await handler.HandleAsync(command);
    }
}
