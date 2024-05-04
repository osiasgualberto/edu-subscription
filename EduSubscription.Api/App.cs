using System.Runtime.InteropServices.ComTypes;
using EduSubscription.Api.Middlewares;
using EduSubscription.Application;
using EduSubscription.Infrastructure;
using Serilog;

namespace EduSubscription.Api;

/// <summary>
/// Main application entrypoint.
/// </summary>
public abstract class App
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder();
        builder.Host.UseSerilog((context, config) =>
        {
            config.ReadFrom.Configuration(context.Configuration);
        });
        builder.Services.AddScoped<ExceptionHandler>();
        builder.Services.AddControllers();
        builder.Services.AddPersistence();
        builder.Services.AddFluentValidation();
        builder.Services.AddAsaas();
        builder.Services.AddBackgroundJobs();
        builder.Services.AddMediator();
        var app = builder.Build();
        app.UseMiddleware<ExceptionHandler>();
        app.MapControllers();
        app.Services.RunMigrations();
        app.Run();
    }
}