using Application.Interfaces;

namespace Shared.Services;

public class DatetimeService : IDatetimeService
{
    public DateTime UtcNow => DateTime.Now;
}