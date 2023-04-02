using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Api.Services;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Generics;

namespace Todo.Domain.Api.Controllers;

[ApiController]
[AllowAnonymous]
[Route("v1/auth")]
public class AuthController: ControllerBase
{
    [Route("token")]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]TokenUserCommand command)
    {

         command.Validate();
         if(command.Invalid)
           return BadRequest(
                new GenericCommandResult(
                    false,"Ops, there's something wrong", command.Notifications
                ));
         var token = TokenService.GenerateToken(command.User);
         return await Task.FromResult(Ok(new GenericCommandResult(true,"Token created successfully", token)));
    }
}

