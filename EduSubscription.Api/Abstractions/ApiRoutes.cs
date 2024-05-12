namespace EduSubscription.Api.Abstractions;

internal static class ApiRoutes
{
    internal static class Subscription
    {
        public const string BaseSubscription = "subscriptions";
        public const string BaseSubscriptionWithId = "subscriptions/{id:guid}";
    }
    
    internal static class Member
    {
        public const string BaseMember = "members";
        public const string BaseMemberWithId = "members/{id:guid}";
    }
    
    internal static class Course
    {
        public const string BaseCourse = "courses";
        public const string BaseCourseLessonWithId = "courses/{id:guid}/lessons";
        public const string BaseCourseWithId = "courses/{id:guid}";
    }

    internal static class Plan
    {
        public const string BasePlan = "plans";
        public const string BasePlanWithId = "plans/{id:guid}";
    }
}