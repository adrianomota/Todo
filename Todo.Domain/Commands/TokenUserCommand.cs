using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;
namespace Todo.Domain.Commands;
public class TokenUserCommand : Notifiable, ICommand
{
    public TokenUserCommand()
    {
        
    }
    public TokenUserCommand(string? user)
    {
        User = user;
    }

    public string? User { get; set; }
    public void Validate()
    {
       AddNotifications(
            new Contract()
            .Requires()
            .HasMinLen(User,3,"User", "Please, fill the User")
        );
    }
}