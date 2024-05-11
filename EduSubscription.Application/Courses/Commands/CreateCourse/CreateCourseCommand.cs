using EduSubscription.Application.Courses.Views;
using EduSubscription.Primitives;
using MediatR;

namespace EduSubscription.Application.Courses.Commands.CreateCourse;

public class CreateCourseCommand : IRequest<Result<CourseCreatedViewModel>>
{
    public CreateCourseCommand(string name, string description)
    {
        Name = name;
        Description = description;
    }
    public string Name { get; set; }
    public string Description { get; set; }
}