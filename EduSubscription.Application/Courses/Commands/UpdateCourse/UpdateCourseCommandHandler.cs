using EduSubscription.Application.Courses.Views;
using EduSubscription.Core.Courses.Errors;
using EduSubscription.Primitives;
using EduSubscription.Repositories;
using MediatR;

namespace EduSubscription.Application.Courses.Commands.UpdateCourse;

public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, Result<CourseUpdatedViewModel>>
{    
    private IUnitOfWork _unitOfWork;

    public UpdateCourseCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result<CourseUpdatedViewModel>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = await _unitOfWork.CourseRepository.ReadById(request.Id);
        if (course is null) return Result.Fail<CourseUpdatedViewModel>(CourseErrors.Course.CourseNotFound);
        course.Update(request.Name, request.Description);
        var courseUpdatedViewModel = new CourseUpdatedViewModel(course.Id);
        return Result.Ok(courseUpdatedViewModel);
    }
}