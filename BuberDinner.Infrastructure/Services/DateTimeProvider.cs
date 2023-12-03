using BuberDinner.Application.Common.Services;

namespace BuberDinner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}