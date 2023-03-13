using BubberDinner.Application.Common.Intercfaces.Persistance;
using BubberDinner.Application.Common.Intercfaces.Services;
using BubberDinner.Infastracture.Authentication;
using BubberDinner.Infastracture.Persistance;
using BubberDinner.Infastracture.Services;
using BuberDinner.Application.Common.Intercfaces.Authentication;
using BuberDinner.Infastracture.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace BuberDinner.Infastracture;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();
        
        return services;
    }
}