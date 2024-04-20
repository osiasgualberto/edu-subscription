using EduSubscription.Subscriptions.Enumerations;

namespace EduSubscription.Application.Subscriptions.Views;

public class SubscriptionCreatedViewModel(
    Guid Id, 
    Guid SubscriptionStatus, 
    EPaymentStatus PaymentStatus
);