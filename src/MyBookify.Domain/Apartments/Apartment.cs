using MyBookify.Domain.Abstractions;
using MyBookify.Domain.Shared;

namespace MyBookify.Domain.Apartments;

public sealed class Apartment : Entity
{
    public Apartment(Guid id)
        : base(id)
    {
    }

    public Name Name { get; private set; }
    public Description Description { get; private set; }
    public Address Address { get; private set; }
    public Money PriceAmount { get; private set; }
    public Currency PriceCurrency { get; private set; }
    public Money CleaningFeeAmount { get; private set; }
    public Currency CleaningFeeCurrency { get; private set; }
    public DateTime? LastBookedOnUtc { get; private set; }
    public List<Amenity> Amenities { get; private set; } = new();
}
