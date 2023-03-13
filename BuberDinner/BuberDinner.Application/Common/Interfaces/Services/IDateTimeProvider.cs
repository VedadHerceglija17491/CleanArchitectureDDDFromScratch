namespace BubberDinner.Application.Common.Intercfaces.Services;

public interface IDateTimeProvider
{
    DateTime UtcNow {get; }
}