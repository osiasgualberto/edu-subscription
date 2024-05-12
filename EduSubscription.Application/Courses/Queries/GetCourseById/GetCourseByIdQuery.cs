using EduSubscription.Application.Courses.Views;
using EduSubscription.Primitives;
using MediatR;

namespace EduSubscription.Application.Courses.Queries.GetCourseById;

public class GetCourseByIdQuery : IRequest<Result<CourseDetailedViewModel>>
{
    public GetCourseByIdQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }   
}