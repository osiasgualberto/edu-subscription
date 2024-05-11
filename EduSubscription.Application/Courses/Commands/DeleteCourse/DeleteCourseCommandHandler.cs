using EduSubscription.Application.Members.Commands.DeleteMember;
using EduSubscription.Core.Courses.Errors;
using EduSubscription.Primitives;
using EduSubscription.Repositories;
using MediatR;

namespace EduSubscription.Application.Courses.Commands.DeleteCourse;

public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCourseCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.CourseRepository.Delete(request.Id);
        await _unitOfWork.Complete();
        if (!result) return Result.Fail(CourseErrors.Course.CourseNotFound);
        return Result.Ok(result);
    }
}