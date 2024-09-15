﻿using System.Data;
using Bogus;
using Dapper;
using MyBookify.Application.Abstractions.Data;
using MyBookify.Domain.Apartments;
using MyBookify.Domain.Users;

namespace MyBookify.Api.Extensions;

internal static class SeedDataExtensions
{
    public static void SeedData(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        ISqlConnectionFactory sqlConnectionFactory = scope.ServiceProvider.GetRequiredService<ISqlConnectionFactory>();
        using IDbConnection connection = sqlConnectionFactory.CreateConnection();

        InsertRole(connection);
    }

    private static void InsertRole(IDbConnection connection)
    {


        const string sql =
            """
              INSERT INTO public.role_user (roles_id, users_id)
              VALUES(@roles_id, @users_id);
            """;

        connection.Execute(sql, new { roles_id = 1, users_id = new Guid("1cd8a1ed-6ef2-4ec1-90a9-c5debedda044") });
    }

    private static void InsertApartmets(IDbConnection connection)
    {
        var faker = new Faker();

        List<object> apartments = new();
        for (int i = 0; i < 100; i++)
        {
            apartments.Add(new
            {
                Id = Guid.NewGuid(),
                Name = faker.Company.CompanyName(),
                Description = "Amazing view",
                Country = faker.Address.Country(),
                State = faker.Address.State(),
                ZipCode = faker.Address.ZipCode(),
                City = faker.Address.City(),
                Street = faker.Address.StreetAddress(),
                PriceAmount = faker.Random.Decimal(50, 1000),
                PriceCurrency = "USD",
                CleaningFeeAmount = faker.Random.Decimal(25, 200),
                CleaningFeeCurrency = "USD",
                Amenities = new List<int> { (int)Amenity.Parking, (int)Amenity.MountainView },
                LastBookedOn = DateTime.MinValue
            });
        }

        const string sql = """
            INSERT INTO public.apartments
            (id, "name", description, address_country, address_state, address_zip_code, address_city, address_street, price_amount, price_currency, cleaning_fee_amount, cleaning_fee_currency, amenities, last_booked_on_utc)
            VALUES(@Id, @Name, @Description, @Country, @State, @ZipCode, @City, @Street, @PriceAmount, @PriceCurrency, @CleaningFeeAmount, @CleaningFeeCurrency, @Amenities, @LastBookedOn);
            """;

        connection.Execute(sql, apartments);
    }

}

