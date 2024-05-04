using EduSubscription.Application.Members.Views;
using EduSubscription.Primitives;
using MediatR;

namespace EduSubscription.Application.Members.Commands.CreateMember;

public class CreateMemberCommand : IRequest<Result<MemberCreatedViewModel>>
{
    public CreateMemberCommand(string firstName, string lastName, string documentNumber, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        DocumentNumber = documentNumber;
        Email = email;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DocumentNumber { get; set; }
    public string Email { get; set; }
}