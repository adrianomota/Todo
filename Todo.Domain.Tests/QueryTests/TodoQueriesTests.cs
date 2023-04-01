using Todo.Domain.Entities;
using Todo.Domain.Queries;
namespace Todo.Domain.Tests.EntityTests;

[TestClass]
public class TodoQueryTests
{
    private List<TodoItem> _items;

    public TodoQueryTests()
    {
        _items = new List<TodoItem>();
        _items.Add(new TodoItem("Tarefa 1", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 2", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 3", "andrebaltieri", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 4", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 5", "andrebaltieri", DateTime.Now));
    }

    [TestMethod]
    public void WHenIHaveSpecificUserVaidReturnsYourTasks()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAll("andrebaltieri"));
        Assert.AreEqual(2, result.Count());
    }
}
