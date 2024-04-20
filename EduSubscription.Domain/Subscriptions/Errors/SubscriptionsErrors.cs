using EduSubscription.Primitives;

namespace EduSubscription.Subscriptions.Errors;

public static class SubscriptionsErrors
{
    public static class Plan
    {
        public static Error PlanNotFound = new("SubscriptionPlan.NotFound", "This subscription plan was not found.");
    }
}