using EduSubscription.Primitives;

namespace EduSubscription.Core.Courses;

public class Lesson : Entity
{
    public Lesson(string name, string description, string link, float minutesDuration, Guid idCourse)
    {
        Name = name;
        Description = description;
        Link = link;
        MinutesDuration = minutesDuration;
        IdCourse = idCourse;
    }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Link { get; private set; }
    public float MinutesDuration { get; private set; }
    public Guid IdCourse { get; private set; }
    public Course Course { get; private set; } = null!;
    public Guid IdModule { get; private set; }
    public Module Module { get; private set; } = null!;
}