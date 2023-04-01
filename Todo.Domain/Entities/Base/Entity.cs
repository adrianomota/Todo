namespace Todo.Domain.Entities.Base;
public abstract class Entity : IEquatable<Entity>
{
    protected Entity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
    }
    public Guid? Id { get;}
    public DateTime? CreatedAt { get; }
    public DateTime? UpdatedAt { get; private set;}

    public bool Equals(Entity? other) => Id == other?.Id;
    public void SetUpdatedAt(DateTime? date) => UpdatedAt = date;
}