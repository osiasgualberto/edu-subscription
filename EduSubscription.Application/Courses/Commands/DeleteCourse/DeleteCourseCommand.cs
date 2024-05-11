using EduSubscription.Primitives;
using MediatR;

namespace EduSubscription.Application.Members.Commands.DeleteMember;

public class DeleteMemberCommand : IRequest<Result>
{
    public DeleteMemberCommand(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}