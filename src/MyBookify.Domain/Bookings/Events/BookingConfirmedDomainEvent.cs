using MyBookify.Domain.Abstractions;

namespace MyBookify.Domain.Bookings.Events;
public sealed record BookingConfirmedDomainEvent(Guid BookingId) : IDomainEvent;
