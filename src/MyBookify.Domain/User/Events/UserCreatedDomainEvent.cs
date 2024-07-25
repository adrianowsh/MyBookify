using MyBookify.Domain.Abstractions;

namespace MyBookify.Domain.User.Events;
public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
