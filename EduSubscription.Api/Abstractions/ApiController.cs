﻿using EduSubscription.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace EduSubscription.Api.Abstractions;

/// <summary>
/// Represents a base controller.
/// </summary>
public class ApiController : ControllerBase
{
    [NonAction]
    public IActionResult BadRequest(Error error) => BadRequest(new ApiErrorResponse(new []{ error }));
    [NonAction]
    public IActionResult NotFound(Error error) => NotFound(new ApiErrorResponse(new[] { error }));
}