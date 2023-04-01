using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Commands.Generics;
using Todo.Domain.Entities;
using Todo.Domain.Repositories;
namespace Todo.Domain.Handlers;
public class TodoHandler : Notifiable, 
            IHandler<CreateTodoCommand>,
            IHandler<UpdateTodoCommand>,
            IHandler<MarkTodoAsDoneCommand>,
            IHandler<MarkTodoAsUnDoneCommand>
{
    private readonly ITodoRepository _repository;
    public TodoHandler(ITodoRepository repository)
    {
        _repository = repository;
    }
    public async Task<ICommandResult> Handle(CreateTodoCommand command)
    {
       command.Validate();
       if(command.Invalid)
         return await Task.FromResult(
            new GenericCommandResult(
                false,"Ops, there's something wrong", command.Notifications
            )
        );
        var newTodo = new TodoItem(command.Title, command.User, DateTime.UtcNow.AddDays(2));
        var todoCreated = await _repository.Create(newTodo);
        return new GenericCommandResult(true, "Task created successfully", todoCreated);
    }

    public async Task<ICommandResult> Handle(UpdateTodoCommand command)
    {
        command.Validate();
        if(command.Invalid)
            return await Task.FromResult(
                new GenericCommandResult(
                    false,"Ops, there's something wrong", command.Notifications
                )
            );
        var todoExists = await _repository.GetById(command.Id, command.User);
        if(todoExists == null)
            return await Task.FromResult(
                new GenericCommandResult(
                    false,"Ops, Todo item doesn't exists", command.Notifications
                )
            );
        todoExists.SetTitle(command?.Title);
        todoExists.SetStartDate(command?.StartDate);
        var todoCreated = await _repository.Update(todoExists);
        return new GenericCommandResult(true, "Task updated successfully", todoCreated);
    }

    public async Task<ICommandResult> Handle(MarkTodoAsDoneCommand command)
    {
        command.Validate();
        if(command.Invalid)
            return await Task.FromResult(
                new GenericCommandResult(
                    false,"Ops, there's something wrong", command.Notifications
                )
            );
        var todoExists = await _repository.GetById(command.Id, command.User);
        if(todoExists == null)
            return await Task.FromResult(
                new GenericCommandResult(
                    false,"Ops, Todo item doesn't exists", command.Notifications
                )
            );
      
        todoExists.SetDone(true);
        var todoCreated = await _repository.Update(todoExists);
        return new GenericCommandResult(true, "Task updated successfully", todoCreated);
    }

    public async Task<ICommandResult> Handle(MarkTodoAsUnDoneCommand command)
    {
        command.Validate();
        if(command.Invalid)
            return await Task.FromResult(
                new GenericCommandResult(
                    false,"Ops, there's something wrong", command.Notifications
                )
            );
        var todoExists = await _repository.GetById(command.Id, command.User);
        if(todoExists == null)
            return await Task.FromResult(
                new GenericCommandResult(
                    false,"Ops, Todo item doesn't exists", command.Notifications
                )
            );
        todoExists.SetDone(false);
        todoExists.SetUpdatedAt(DateTime.UtcNow);
        var todoCreated = await _repository.Update(todoExists);
        return new GenericCommandResult(true, "Task updated successfully", todoCreated);
    }
}