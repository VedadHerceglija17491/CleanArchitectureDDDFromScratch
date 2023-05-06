using BubberDinner.Api.Common.Errors;
using BuberDinner.Application;
using BuberDinner.Infastracture;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
   
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthentication(); // dodatii
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}


