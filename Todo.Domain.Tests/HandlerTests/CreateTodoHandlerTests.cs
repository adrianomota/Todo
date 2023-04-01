using Todo.Domain.Commands;
using Todo.Domain.Commands.Generics;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;
namespace Todo.Domain.Tests.HandlerTests;
[TestClass]
public class CreateTodoHandlerTests
{
    [TestMethod]
    public async Task WhenHandlerIsInvalidReturnError()
    {
        var command = new CreateTodoCommand("", "",DateTime.UtcNow.AddDays(-1));
        var handler = new TodoHandler(new FakeTodoRepository());
        var result = (GenericCommandResult) await handler.Handle(command);
        Assert.AreEqual(result.Success, false);
    }

    [TestMethod]
    public async Task WhenHandlerIsvalidReturnSuccess()
    {
        var command = new CreateTodoCommand("Todo title", "adriano", DateTime.UtcNow.AddDays(1));
        var handler = new TodoHandler(new FakeTodoRepository());
        var result = (GenericCommandResult) await handler.Handle(command);
        Assert.AreEqual(result.Success, true);
    }
}