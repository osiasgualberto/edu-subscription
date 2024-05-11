using EduSubscription.Api.Abstractions;
using EduSubscription.Application.Courses.Commands.CreateCourse;
using EduSubscription.Application.Courses.Commands.DeleteCourse;
using EduSubscription.Application.Courses.Commands.UpdateCourse;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduSubscription.Api.Controllers;

[ApiController]
[Route("api")]
public class CourseController : ApiController
{
    public CourseController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    private readonly IMediator _mediator;
    
    [HttpPost(ApiRoutes.Course.BaseCourse)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PostCourse([FromBody] CreateCourseCommand createCourseCommand)
    {
        var result = await _mediator.Send(createCourseCommand);
        return result.IsSuccess ? CreatedAtAction(nameof(PostCourse), value: result.Value) : BadRequest(result.Error);
    }
    
    [HttpPut(ApiRoutes.Course.BaseCourseWithId)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PutCourse(Guid id, [FromBody] UpdateCourseCommand updateCourseCommand)
    {
        updateCourseCommand.Id = id;
        var result = await _mediator.Send(updateCourseCommand);
        return result.IsSuccess ? CreatedAtAction(nameof(PutCourse), value: result.Value) : BadRequest(result.Error);
    }
    
    [HttpDelete(ApiRoutes.Course.BaseCourseWithId)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteCourse(Guid id)
    {
        var result = await _mediator.Send(new DeleteCourseCommand(id));
        return result.IsSuccess ? NoContent() : BadRequest(result.Error);
    }
 
}