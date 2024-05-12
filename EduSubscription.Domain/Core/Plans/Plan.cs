using EduSubscription.Primitives;

namespace EduSubscription.Core.Plans;

public class Plan : Entity
{
    public Plan(string description, int monthDuration)
    {
        Description = description;
        MonthDuration = monthDuration;
    }
    
    public string Description { get; private set; }
    public int MonthDuration { get; private set; }

    /// <summary>
    /// Updates the current plan object.
    /// </summary>
    /// <param name="description"></param>
    /// <param name="installments"></param>
    public void Update(string description, int installments)
    {
        Description = description;
        MonthDuration = installments;
    }
    
}