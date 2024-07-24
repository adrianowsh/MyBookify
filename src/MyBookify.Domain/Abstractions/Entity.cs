namespace MyBookify.Domain.Abstractions;
public abstract class Entity
{
    protected Entity(Guid id)
    {
        Id = id;
        InsertedAt = DateTime.Now;
    }
    public Guid Id { get; init; }

    public DateTime InsertedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
}
