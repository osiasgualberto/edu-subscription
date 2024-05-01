using EduSubscription.Core.Plans;
using EduSubscription.Core.Subscriptions.Enumerations;
using EduSubscription.Core.Subscriptions.Events;
using EduSubscription.Primitives;

namespace EduSubscription.Core.Subscriptions;

public class Subscription : Entity
{
    private Subscription(ESubscriptionStatus status, DateOnly start, DateOnly end, Guid idPlan)
    {
        Status = status;
        Start = start;
        End = end;
        IdPlan = idPlan;
    }

    public static Subscription Create(Guid idPlan)
    {
        DateTime today = DateTime.Now;
        DateOnly start = new DateOnly(today.Year, today.Month, today.Day);
        DateOnly end = new DateOnly(today.Year, today.Month, today.Day);
        Subscription subscription = new Subscription(ESubscriptionStatus.Pending, start, end, idPlan);
        subscription.Raise(new SubscriptionCreatedEvent(subscription.Id, Guid.NewGuid(), 100.00));
        return subscription;
    }
    
    public Guid IdPlan { get; private set; }
    public Plan Plan { get; private set; } = null!;
    public ESubscriptionStatus Status { get; private set; }
    public DateOnly Start { get; private set; }
    public DateOnly End { get; private set; }
}