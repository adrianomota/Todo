using Todo.Domain.Entities.Base;
namespace Todo.Domain.Entities;
public class TodoItem: Entity
{
    public TodoItem(string? title, string? user, DateTime? startDate)
    {
        Title = title;
        User = user;
        StartDate = startDate;
        Done = false;
    }
    public string? Title { get; private set;}
    public bool? Done { get; private set; }
    public string? User { get; private set; }
    public DateTime? StartDate { get; private set; }
    public void SetDone(bool? value) => Done = value;
    public void SetTitle(string? title) => Title = title;
    public void SetStartDate(DateTime? startDate) => StartDate = startDate;
}