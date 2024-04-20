using EduSubscription.Core.Subscriptions.Enumerations;

namespace EduSubscription.Application.Subscriptions.Views;

public record SubscriptionViewModel(
    Guid IdPlan,
    ESubscriptionStatus Status,
    DateOnly Start,
    DateOnly End
);