using EduSubscription.Application.Courses.Commands.CreateCourse;
using EduSubscription.Application.Courses.Views;
using EduSubscription.Core.Courses;
using EduSubscription.Core.Courses.Errors;
using EduSubscription.Primitives;
using EduSubscription.Repositories;
using MediatR;

namespace EduSubscription.Application.Courses.Commands.CreateCourseLesson;

public class CreateCourseLessonCommandHandler : IRequestHandler<CreateCourseLessonCommand, Result<CourseLessonCreatedViewModel>>
{
    private IUnitOfWork _unitOfWork;

    public CreateCourseLessonCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<CourseLessonCreatedViewModel>> Handle(CreateCourseLessonCommand request, CancellationToken cancellationToken)
    {
        var course = await _unitOfWork.CourseRepository.ReadById(request.IdCourse);
        if (course is null)
        {
            return Result.Fail<CourseLessonCreatedViewModel>(CourseErrors.Course.CourseNotFound);
        }
        var lesson = Lesson.Create(course.Id, request.Name, request.Description);
        course.AddLesson(lesson);
        await _unitOfWork.Complete();
        var courseLessonCreatedViewModel = new CourseLessonCreatedViewModel(lesson.Id);
        return Result.Ok(courseLessonCreatedViewModel);
    }
}