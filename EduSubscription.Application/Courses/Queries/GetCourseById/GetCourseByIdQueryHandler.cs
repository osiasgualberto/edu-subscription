using EduSubscription.Application.Courses.Views;
using EduSubscription.Core.Courses.Errors;
using EduSubscription.Primitives;
using EduSubscription.Repositories;
using MediatR;

namespace EduSubscription.Application.Courses.Queries.GetCourseById;

public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, Result<CourseDetailedViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCourseByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CourseDetailedViewModel>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        var course = await _unitOfWork.CourseRepository.ReadById(request.Id);
        if (course is null) return Result.Fail<CourseDetailedViewModel>(CourseErrors.Course.CourseNotFound);
        var courseViewModel = new CourseDetailedViewModel(course.Id, course.Name, course.Description, course.Lessons.Select(
            o =>
            {
                return new LessonViewModel(o.Name, o.Description);
            }).ToList());
        return Result.Ok(courseViewModel);
    }
}