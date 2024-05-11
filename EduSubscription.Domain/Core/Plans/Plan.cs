using EduSubscription.Primitives;

namespace EduSubscription.Core.Plans;

public class Plan : Entity
{
    public Plan(string description, int installments)
    {
        Description = description;
        Installments = installments;
    }
    
    public string Description { get; private set; }
    public int Installments { get; private set; }

    /// <summary>
    /// Updates the current plan object.
    /// </summary>
    /// <param name="description"></param>
    /// <param name="installments"></param>
    public void Update(string description, int installments)
    {
        Description = description;
        Installments = installments;
    }
    
}