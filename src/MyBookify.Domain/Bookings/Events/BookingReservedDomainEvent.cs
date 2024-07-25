using MyBookify.Domain.Abstractions;

namespace MyBookify.Domain.Bookings.Events;
public sealed record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;
