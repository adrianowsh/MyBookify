using MyBookify.Domain.Abstractions;

namespace MyBookify.Domain.Bookings.Events;
public sealed record BookingCompletedDomainEvent(Guid BookingId) : IDomainEvent;
