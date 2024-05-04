using EduSubscription.Primitives;

namespace EduSubscription.Core.Plans;

public class Plan : Entity
{
    public Plan(string description, int durationInMonths)
    {
        Description = description;
        DurationInMonths = durationInMonths;
    }
    public int DurationInMonths { get; private set; }
    public string Description { get; private set; }

    /// <summary>
    /// Updates the current plan object.
    /// </summary>
    /// <param name="description"></param>
    /// <param name="duration"></param>
    public void Update(string description, int duration)
    {
        Description = description;
        DurationInMonths = duration;
    }
    
}