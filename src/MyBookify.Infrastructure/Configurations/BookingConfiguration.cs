﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBookify.Domain.Apartments;
using MyBookify.Domain.Bookings;
using MyBookify.Domain.Shared;
using MyBookify.Domain.Users;

namespace MyBookify.Infrastructure.Configurations;
internal sealed class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("bookings");

        builder.HasKey(booking => booking.Id);

        builder.OwnsOne(booking => booking.PriceForPeriod, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });

        builder.OwnsOne(booking => booking.CleaningFee, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });

        builder.OwnsOne(booking => booking.AmenitiesUpCharge, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });

        builder.OwnsOne(booking => booking.TotalPrice, priceBuilder =>
        {
            priceBuilder.Property(money => money.Currency)
                .HasConversion(currency => currency.Code, code => Currency.FromCode(code));
        });

        builder.OwnsOne(booking => booking.Duration);

        builder.HasOne<Apartment>()
            .WithMany()
            .HasForeignKey(booking => booking.ApartmentId);

        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(booking => booking.UserId);
    }
}
