using EduSubscription.Primitives.Contracts;

namespace EduSubscription.Core.Subscriptions.Events;

public class SubscriptionCreatedEvent : IDomainEvent
{
    public SubscriptionCreatedEvent(Guid subscriptionId)
    {
        SubscriptionId = subscriptionId;
    }
    public Guid SubscriptionId { get; set; }
}