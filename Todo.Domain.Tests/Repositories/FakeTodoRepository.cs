using Todo.Domain.Entities;
using Todo.Domain.Repositories;
namespace Todo.Domain.Tests.Repositories;
public class FakeTodoRepository : ITodoRepository
{
    public async Task<TodoItem> Create(TodoItem todo)
    {
        return await Task.FromResult(new TodoItem("Title todo createed", "Todo 1 created", DateTime.Now));
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

    public async Task<TodoItem> GetById(Guid? id, string user)
    {
        return await Task.FromResult(new TodoItem("Title here", "Todo 1", DateTime.Now));
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
