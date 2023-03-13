using BubberDinner.Application.Common.Intercfaces.Services;

namespace BubberDinner.Infastracture.Services;


public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}