using Todo.Domain.Entities;
using Todo.Domain.Repositories;
namespace Todo.Domain.Tests.Repositories;
public class FakeTodoRepository : ITodoRepository
{
    public Task<TodoItem> Create(TodoItem todo)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TodoItem>> GetAll(string? user)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TodoItem>> GetAllDone(string? user)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TodoItem>> GetAllUndone(string? user)
    {
        throw new NotImplementedException();
    }

    public Task<TodoItem> GetById(Guid? id, string user)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TodoItem>> GetByPeriod(string? user, DateTime? date, bool? done)
    {
        throw new NotImplementedException();
    }

    public Task<TodoItem> Update(TodoItem todo)
    {
        throw new NotImplementedException();
    }
}
