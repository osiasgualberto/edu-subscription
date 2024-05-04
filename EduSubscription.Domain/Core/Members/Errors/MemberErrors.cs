using EduSubscription.Primitives;

namespace EduSubscription.Core.Members.Errors;

public static class MemberErrors
{
    public static class Member
    {
        public static Error MemberNotFound = new("Member.NotFound", "This member was not found.");
    }
}