using EduSubscription.Primitives.Contracts;
using MediatR;

namespace EduSubscription.Core.Subscriptions.Events;

public record SubscriptionCreatedEvent : IDomainEvent;