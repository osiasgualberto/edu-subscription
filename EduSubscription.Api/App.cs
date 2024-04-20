using EduSubscription.Api.Middlewares;
using EduSubscription.Application;
using EduSubscription.Infrastructure;

namespace EduSubscription.Api;

/// <summary>
/// Main application entrypoint.
/// </summary>
public abstract class App
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddScoped<ExceptionHandler>();
        builder.Services.AddControllers();
        builder.Services.AddPersistence();
        builder.Services.AddFluentValidation();
        builder.Services.AddMediator();
        var app = builder.Build();
        app.UseMiddleware<ExceptionHandler>();
        app.MapControllers();
        app.Services.RunMigrations();
        app.Run();
    }
}