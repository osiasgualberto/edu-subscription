using System.Net;
using System.Text.Json;
using EduSubscription.Api.Abstractions;
using EduSubscription.Application.Exceptions;
using EduSubscription.Primitives;

namespace EduSubscription.Api.Middlewares;

/// <summary>
/// Represents a global exception handler.
/// </summary>
public class ExceptionHandler : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (CustomValidationException exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var errorsList = new List<Error>();
            foreach (var errors in exception.Errors)
            {
                errorsList.Add(new Error("Server.ValidationError", errors.Message));
            }
            var apiErrorResponse =
                new ApiErrorResponse(errorsList.ToArray());
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var json = JsonSerializer.Serialize(apiErrorResponse, options);
            await context.Response.WriteAsync(json);
        }
        catch (Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var apiErrorResponse = new ApiErrorResponse(new[] { new Error("Server.UnknownError", exception.Message)});
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var json = JsonSerializer.Serialize(apiErrorResponse, options);
            await context.Response.WriteAsync(json);
        }
    }
}