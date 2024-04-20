using EduSubscription.Primitives;
using EduSubscription.Subscriptions.Enumerations;

namespace EduSubscription.Subscriptions;

public class Subscription : Entity
{
    public Subscription(ESubscriptionStatus status, DateOnly start, DateOnly end, Guid idPlan, Guid idPayment)
    {
        Status = status;
        Start = start;
        End = end;
        IdPlan = idPlan;
        IdPayment = idPayment;
    }
    public Guid IdPlan { get; private set; }
    public Plan Plan { get; private set; } = null!;
    public Guid IdPayment { get; private set; }
    public Payment Payment { get; private set; } = null!;
    public ESubscriptionStatus Status { get; private set; }
    public DateOnly Start { get; private set; }
    public DateOnly End { get; private set; }
}