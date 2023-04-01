using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;
namespace Todo.Domain.Commands;
public class UpdateTodoCommand : Notifiable, ICommand
{
    public Guid? Id { get; private set; }
    public string? Title { get; private set;}
    public bool? Done { get; private set; }
    public string? User { get; private set; }
    public DateTime? StartDate { get; set; }
    public void Validate()
    {
       AddNotifications(
            new Contract()
            .Requires()
            .HasMinLen(Title,3,"Title", "Please, fill the title")
            .HasMinLen(User,3,"User", "Please, fill the User")
        );
    }
}