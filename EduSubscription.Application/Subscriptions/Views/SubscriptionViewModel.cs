using EduSubscription.Core.Subscriptions.Enumerations;

namespace EduSubscription.Application.Subscriptions.Views;

public record SubscriptionViewModel(
    Guid Id,
    Guid IdPlan,
    Guid idMember,
    ESubscriptionStatus Status,
    DateOnly Start,
    DateOnly End
);