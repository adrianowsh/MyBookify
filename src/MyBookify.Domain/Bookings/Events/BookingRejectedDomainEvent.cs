using MyBookify.Domain.Abstractions;

namespace MyBookify.Domain.Bookings.Events;
public sealed record BookingRejectedDomainEvent(Guid BookingId) : IDomainEvent;
