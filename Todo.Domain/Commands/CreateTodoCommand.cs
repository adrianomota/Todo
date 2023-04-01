using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;
namespace Todo.Domain.Commands;
public class CreateTodoCommand : Notifiable, ICommand
{
    public CreateTodoCommand(){ }
    public CreateTodoCommand(string? title, string? user, DateTime? startDate)
    {
        Title = title;
        User = user;
        StartDate = startDate;
    }

    public string? Title { get;  set;}
    public string? User { get;  set; }
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