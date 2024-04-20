using EduSubscription.Subscriptions.Enumerations;

namespace EduSubscription.Application.Subscriptions.Views;

public record SubscriptionViewModel(
    Guid IdPlan,
    Guid IdPayment,
    ESubscriptionStatus Status,
    DateOnly Start,
    DateOnly End
);