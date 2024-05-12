using EduSubscription.Application.Courses.Views;
using MediatR;

namespace EduSubscription.Application.Courses.Queries.GetAllCourses;

public class GetAllCoursesQuery : IRequest<List<CourseDetailedViewModel>>;