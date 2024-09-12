using MyBookify.Application.Abstractions.Messaging;

namespace MyBookify.Application.Bookings.GetBooking;
public sealed record GetBookingQuery(Guid BookingId) : IQuery<BookingResponse>
{
    public string CacheKey => $"bookings-{BookingId}";

    public static TimeSpan? Expiration => null;
}
