

using BubberDinner.Api.Common.Errors;
using BubberDinner.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(
        this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}