using EduSubscription.Core.Payments.Enumerations;

namespace EduSubscription.Application.Subscriptions.Views;

public record SubscriptionCreatedViewModel(
    Guid Id, 
    Guid SubscriptionStatus, 
    EPaymentStatus PaymentStatus
);