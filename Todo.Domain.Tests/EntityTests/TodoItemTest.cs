using Todo.Domain.Entities;
namespace Todo.Domain.Tests.EntityTests;
[TestClass]
public class TodoItemTests
{
    [TestMethod]
    public void WhenCreatedTodoItemItCanBeConclude()
    {
        var todo = new TodoItem("Task 1", "adriano", DateTime.UtcNow.AddDays(1));
        Assert.AreEqual(todo.Done, false);
    }
}