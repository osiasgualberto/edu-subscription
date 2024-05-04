using EduSubscription.Application.Members.Views;
using EduSubscription.Primitives;
using MediatR;

namespace EduSubscription.Application.Members.Queries.GetMemberById;

public class GetMemberByIdQuery : IRequest<Result<MemberViewModel>>
{
    public GetMemberByIdQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}