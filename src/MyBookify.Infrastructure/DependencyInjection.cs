using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBookify.Application.Abstractions.Clock;
using MyBookify.Application.Abstractions.Data;
using MyBookify.Application.Abstractions.Email;
using MyBookify.Domain.Abstractions;
using MyBookify.Domain.Apartments;
using MyBookify.Domain.Bookings;
using MyBookify.Domain.Users;
using MyBookify.Infrastructure.Clock;
using MyBookify.Infrastructure.Data;
using MyBookify.Infrastructure.Email;
using MyBookify.Infrastructure.Repositories;

namespace MyBookify.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
       this IServiceCollection services,
       IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();

        services.AddTransient<IEmailService, EmailService>();

        AddPersistence(services, configuration);
        return services;
    }


    private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Database") ??
                                  throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention());

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IApartmentRepository, ApartmentRepository>();

        services.AddScoped<IBookingRepository, BookingRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ =>
            new SqlConnectionFactory(connectionString));

        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
    }
}
