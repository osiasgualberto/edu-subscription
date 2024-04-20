using EduSubscription.Primitives;

namespace EduSubscription.Application.Exceptions;

/// <summary>
/// Represents a custom validation exception.
/// </summary>
public class CustomValidationException : Exception
{
    public Error[] Errors { get; }

    public CustomValidationException(Error[] errors)
    {
        Errors = errors;
    }
}