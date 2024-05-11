using EduSubscription.Application.Courses.Views;
using EduSubscription.Primitives;
using MediatR;

namespace EduSubscription.Application.Courses.Commands.UpdateCourse;

public class UpdateCourseCommand : IRequest<Result<CourseUpdatedViewModel>>
{
    public UpdateCourseCommand(Guid id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}