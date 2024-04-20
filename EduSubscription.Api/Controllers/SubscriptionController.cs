using System.Net;
using EduSubscription.Api.Abstractions;
using EduSubscription.Application.Subscriptions.Commands.CreatePlan;
using EduSubscription.Application.Subscriptions.Commands.CreateSubscription;
using EduSubscription.Application.Subscriptions.Queries.GetAllSubscriptions;
using EduSubscription.Application.Subscriptions.Views;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EduSubscription.Api.Controllers;

[ApiController]
[Route("api")]
public class SubscriptionController : ApiController
{
    public SubscriptionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;
    
    [HttpPost(ApiRoutes.Subscription.BaseSubscription)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostSubscription([FromBody] CreateSubscriptionCommand createSubscriptionCommand)
    {
        var result = await _mediator.Send(createSubscriptionCommand);
        return result.IsSuccess ? CreatedAtAction(nameof(PostSubscription), value: result.Value) : BadRequest(result.Error);
    }
    
    [HttpGet(ApiRoutes.Subscription.BaseSubscription)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllSubscriptions()
    {
        var view = await _mediator.Send(new GetAllSubscriptionsQuery());
        return Ok(view);    
    }
    
}