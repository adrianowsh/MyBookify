using MyBookify.Domain.Shared;

namespace MyBookify.Domain.Bookings;
public sealed record PricingDetails(
    Money PriceForPeriod,
    Money CleaningFee,
    Money AmenitiesUpCharge,
    Money TotalPrice);
