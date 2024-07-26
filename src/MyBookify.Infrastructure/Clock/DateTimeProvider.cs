using MyBookify.Application.Abstractions.Clock;

namespace MyBookify.Infrastructure.Clock;
internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}

