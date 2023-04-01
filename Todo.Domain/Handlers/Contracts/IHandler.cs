using Todo.Domain.Commands.Contracts;
namespace Todo.Domain.Handlers;
public interface IHandler<T> where T : ICommand
{
    Task<ICommandResult> Handle(T command);
}