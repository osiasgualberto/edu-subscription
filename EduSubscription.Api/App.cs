namespace EduSubscription.Api;

/// <summary>
/// Main application entrypoint.
/// </summary>
public abstract class App
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder();
        builder.Services.AddControllers();
        var app = builder.Build();
        app.MapControllers();
        app.Run();
    }
}