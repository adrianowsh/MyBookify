using MyBookify.Domain.Abstractions;

namespace MyBookify.Domain.Bookings.Events;
public sealed record BookingCancelledDomainEvent(Guid BookingId) : IDomainEvent;
