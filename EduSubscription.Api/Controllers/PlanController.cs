using EduSubscription.Api.Abstractions;
using EduSubscription.Application.Plans.Commands.CreatePlan;
using EduSubscription.Application.Plans.Queries.GetAllPlans;
using EduSubscription.Application.Subscriptions.Queries.GetAllSubscriptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduSubscription.Api.Controllers;

[ApiController]
[Route("api")]
public class PlanController : ApiController
{
    public PlanController(IMediator mediator)
    {
        _mediator = mediator;
    }

    private readonly IMediator _mediator;

    [HttpPost(ApiRoutes.Plan.BasePlan)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostPlan([FromBody] CreatePlanCommand createPlanCommand)
    {
        var result = await _mediator.Send(createPlanCommand);
        return result.IsSuccess ? CreatedAtAction(nameof(PostPlan), value: result.Value) : BadRequest(result.Error);
    }
    
    [HttpGet(ApiRoutes.Plan.BasePlan)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPlans()
    {
        var view = await _mediator.Send(new GetAllPlansQuery());
        return Ok(view);
    }
}