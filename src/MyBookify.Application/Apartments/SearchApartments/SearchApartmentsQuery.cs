using MyBookify.Application.Abstractions.Messaging;

namespace MyBookify.Application.Apartments.SearchApartments;
public sealed record SearchApartmentsQuery(
    DateOnly StartDate,
    DateOnly EndDate) : IQuery<IReadOnlyList<ApartmentResponse>>;
