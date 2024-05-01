using EduSubscription.Primitives.Contracts;

namespace EduSubscription.Core.Subscriptions.Events;

public class SubscriptionCreatedEvent : IDomainEvent
{
    public SubscriptionCreatedEvent(Guid subscriptionId, Guid memberId, double value)
    {
        SubscriptionId = subscriptionId;
        MemberId = memberId;
        Value = value;
    }
    public Guid SubscriptionId { get; set; }
    public Guid MemberId { get; set; }
    public double Value { get; set; }
}