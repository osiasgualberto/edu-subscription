using EduSubscription.Primitives;
using MediatR;

namespace EduSubscription.Application.Courses.Commands.DeleteCourse;

public class DeleteCourseCommand : IRequest<Result>
{
    public DeleteCourseCommand(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}