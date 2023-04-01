using Todo.Domain.Commands;
namespace Todo.Domain.Tests.CommandTests;
[TestClass]
public class CreateTodoCommandTests
{
    [TestMethod]
    public void WhenCommandIsInvalidReturnError()
    {
        var command = new CreateTodoCommand("", "", DateTime.UtcNow.AddDays(1));
        command.Validate();
        Assert.AreEqual(command.Valid, false);
    }

    [TestMethod]
    public void WhenCommandIsvalidReturnSuccess()
    {
        var command = new CreateTodoCommand("Todo title", "adriano", DateTime.UtcNow.AddDays(1));
        command.Validate();
        Assert.AreEqual(command.Valid, true);
    }
}