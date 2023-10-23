namespace PackerApp.Shared.Abstractions.Commands;

public interface ICommandHandler<TCommand> where TCommand: class, ICommand 
{
    Task HandleAsync(TCommand command);
}
