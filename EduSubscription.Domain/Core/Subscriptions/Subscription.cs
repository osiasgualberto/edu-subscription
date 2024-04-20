using EduSubscription.Core.Plans;
using EduSubscription.Core.Subscriptions.Enumerations;
using EduSubscription.Primitives;

namespace EduSubscription.Core.Subscriptions;

public class Subscription : Entity
{
    public Subscription(ESubscriptionStatus status, DateOnly start, DateOnly end, Guid idPlan)
    {
        Status = status;
        Start = start;
        End = end;
        IdPlan = idPlan;
    }
    public Guid IdPlan { get; private set; }
    public Plan Plan { get; private set; } = null!;
    public ESubscriptionStatus Status { get; private set; }
    public DateOnly Start { get; private set; }
    public DateOnly End { get; private set; }
}