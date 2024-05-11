using EduSubscription.Application.Courses.Views;
using EduSubscription.Core.Courses.Errors;
using EduSubscription.Primitives;
using EduSubscription.Repositories;
using MediatR;

namespace EduSubscription.Application.Courses.Queries.GetCourseById;

public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, Result<CourseViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCourseByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CourseViewModel>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        var course = await _unitOfWork.CourseRepository.ReadById(request.Id);
        if (course is null) return Result.Fail<CourseViewModel>(CourseErrors.Course.CourseNotFound);
        var courseViewModel = new CourseViewModel(course.Id, course.Name, course.Description);
        return Result.Ok(courseViewModel);
    }
}