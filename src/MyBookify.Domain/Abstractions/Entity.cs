﻿namespace MyBookify.Domain.Abstractions;
public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();
    protected Entity(Guid id)
    {
        Id = id;
        InsertedAt = DateTime.Now;
    }

    protected Entity()
    {
    }

    public Guid Id { get; init; }
    public DateTime InsertedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }

    public IReadOnlyList<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
