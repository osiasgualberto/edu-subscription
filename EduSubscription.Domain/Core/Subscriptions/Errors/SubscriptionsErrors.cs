using EduSubscription.Primitives;

namespace EduSubscription.Core.Subscriptions.Errors;

public static class SubscriptionsErrors
{
    public static class Subscription
    {
        public static Error SubscriptionNotFound = new("Subscription.NotFound", "The subscription was not found.");
    }
}