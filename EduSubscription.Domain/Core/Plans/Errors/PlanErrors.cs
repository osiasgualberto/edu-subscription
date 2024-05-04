using EduSubscription.Primitives;

namespace EduSubscription.Core.Plans.Errors;

public static class PlanErrors
{
    public static class Plan
    {
        public static Error PlanNotFound = new("Plan.NotFound", "This subscription plan was not found.");
    }
}