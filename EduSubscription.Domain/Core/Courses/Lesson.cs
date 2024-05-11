using EduSubscription.Primitives;

namespace EduSubscription.Core.Courses;

public class Lesson : Entity
{
    public Lesson(string name, string description, string link, float minutesDuration)
    {
        Name = name;
        Description = description;
        Link = link;
        MinutesDuration = minutesDuration;
    }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Link { get; private set; }
    public float MinutesDuration { get; private set; }
}