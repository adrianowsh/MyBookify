using MyBookify.Domain.Abstractions;

namespace MyBookify.Domain.Users.Events;
public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
