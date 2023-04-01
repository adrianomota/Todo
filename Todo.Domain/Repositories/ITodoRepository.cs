using Todo.Domain.Entities;
namespace Todo.Domain.Repositories;
public interface ITodoRepository
{
    Task<TodoItem> Create(TodoItem todo);
    Task<TodoItem> Update(TodoItem todo);
    Task<TodoItem> GetById(Guid? id, string user);
    Task<IEnumerable<TodoItem>> GetAll(string? user);
    Task<IEnumerable<TodoItem>> GetAllDone(string? user);
    Task<IEnumerable<TodoItem>> GetAllUndone(string? user);
    Task<IEnumerable<TodoItem>> GetByPeriod(string? user, DateTime? date, bool? done);
} 