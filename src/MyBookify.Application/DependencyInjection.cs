using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using MyBookify.Application.Abstractions.Behaviors;
using MyBookify.Domain.Bookings;

namespace MyBookify.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddConfiguration(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));

            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, includeInternalTypes: true);

        services.AddTransient<PricingService>();

        return services;
    }
}
