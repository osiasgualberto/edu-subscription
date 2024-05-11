using EduSubscription.Primitives;

namespace EduSubscription.Core.Courses;

public class Module : Entity
{
    public Module(string name, string description, DateTime createdAt)
    {
        Name = name;
        Description = description;
        CreatedAt = createdAt;
    }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
}