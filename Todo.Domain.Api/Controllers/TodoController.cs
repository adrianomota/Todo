using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Generics;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;
namespace Todo.Domain.Api.Controllers;

[ApiController]
[Authorize]
[Route("v1/todos")]
public class TodoController : ControllerBase
{   
    [Route("create")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateTodoCommand command,
                                            [FromServices]TodoHandler handler)
    {
        command.User = "adriano";
        var result = (GenericCommandResult) await handler.Handle(command);
        return Ok(result);
    }

    [Route("all")]
    [HttpGet]
    public async Task<IActionResult> Get([FromServices] ITodoRepository repo)
    {
        var result = await repo.GetAll("adriano");
        return Ok(result);
    }

    [Route("mark-as-done")]
    [HttpPut]
    public async Task<IActionResult> MarkAsDone(
            [FromBody]MarkTodoAsDoneCommand command,
            [FromServices]TodoHandler handler
    )
    {
        command.User = "adriano";
        var result = (GenericCommandResult) await handler.Handle(command);
        return Ok(result);
    }

    [Route("mark-as-undone")]
    [HttpPut]
     public async Task<IActionResult> MarkAsUndone(
        [FromBody]MarkTodoAsUndoneCommand command,
        [FromServices]TodoHandler handler
    )
    {
        command.User = "adriano";
        var result  = (GenericCommandResult) await handler.Handle(command);
        return Ok(result);
    }
}