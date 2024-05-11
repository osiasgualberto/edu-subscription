using EduSubscription.Application.Courses.Views;
using EduSubscription.Repositories;
using MediatR;

namespace EduSubscription.Application.Courses.Queries.GetAllCourses;

public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, List<CourseViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllCoursesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<CourseViewModel>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
    {
        var courses = await _unitOfWork.CourseRepository.ReadAll();
        return courses
            .Select(o => new CourseViewModel(o.Id, o.Name, o.Description))
            .ToList();
    }
}