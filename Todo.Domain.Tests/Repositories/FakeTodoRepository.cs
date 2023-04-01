using Todo.Domain.Entities;
using Todo.Domain.Repositories;
namespace Todo.Domain.Tests.Repositories;
public class FakeTodoRepository : ITodoRepository
{
    public async Task<TodoItem> Create(TodoItem todoItem)
    {
        return await Task.FromResult(new TodoItem("Task one", "current user name", DateTime.UtcNow.AddDays(1)));
    }

    public Task<TodoItem> GetById(Guid? id)
    {
        throw new NotImplementedException();
    }

    public async Task<TodoItem> Update(TodoItem todoItem)
    {
        return await Task.FromResult(new TodoItem("Task one updated", "current user name updated", DateTime.UtcNow.AddDays(-1)));
    }
}
