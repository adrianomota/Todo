using Todo.Domain.Entities;
namespace Todo.Domain.Repositories;
public interface ITodoRepository
{
    Task<TodoItem> Create(TodoItem todoItem);
    Task<TodoItem> Update(TodoItem todoItem);
    Task<TodoItem> GetById(Guid? id);
} 