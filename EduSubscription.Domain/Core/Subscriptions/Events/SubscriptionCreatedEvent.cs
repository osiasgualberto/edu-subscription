using EduSubscription.Primitives.Contracts;

namespace EduSubscription.Core.Subscriptions.Events;

public class SubscriptionCreatedEvent : IDomainEvent
{
    public SubscriptionCreatedEvent(Guid idSubscription, Guid idMember, Guid planId)
    {
        IdSubscription = idSubscription;
        IdMember = idMember;
        PlanId = planId;
    }
    public Guid IdSubscription { get; set; }
    public Guid IdMember { get; set; }
    public Guid PlanId { get; set; }
}