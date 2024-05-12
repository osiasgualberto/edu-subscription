using FluentValidation;

namespace EduSubscription.Application.Courses.Commands.CreateCourse;

public class CreateCourseLessonCommandValidator : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseLessonCommandValidator()
    {
        RuleFor(o => o.Name).NotEmpty().MaximumLength(30);
        RuleFor(o => o.Description).MaximumLength(200);
    }
}