using EduSubscription.Application.Members.Views;
using EduSubscription.Primitives;
using MediatR;

namespace EduSubscription.Application.Members.Commands.UpdateMember;

public class UpdateMemberCommand : IRequest<Result<MemberUpdatedViewModel>>
{
    public UpdateMemberCommand(Guid id, string firstName, string lastName, string documentNumber)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        DocumentNumber = documentNumber;
    }
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DocumentNumber { get; set; }
}