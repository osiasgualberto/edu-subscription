using EduSubscription.Primitives;

namespace EduSubscription.Subscriptions;

public class Plan : Entity
{
    public Plan(string description, int durationInMonths)
    {
        Description = description;
        DurationInMonths = durationInMonths;
    }

    public int DurationInMonths { get; private set; }
    public string Description { get; private set; }
}