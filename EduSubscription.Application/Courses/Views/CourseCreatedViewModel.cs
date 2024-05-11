namespace EduSubscription.Application.Courses.Views;

public class CourseCreatedViewModel
{
    public CourseCreatedViewModel(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}