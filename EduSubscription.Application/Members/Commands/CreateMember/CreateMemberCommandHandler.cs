using EduSubscription.Application.Members.Views;
using EduSubscription.Core.Members;
using EduSubscription.Core.Members.Enumerations;
using EduSubscription.Primitives;
using EduSubscription.Repositories;
using MediatR;

namespace EduSubscription.Application.Members.Commands.CreateMember;

public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Result<MemberCreatedViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateMemberCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<MemberCreatedViewModel>> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
    {
        var member = new Member(request.FirstName, request.LastName, request.DocumentNumber, request.Email, ERole.Student, true);
        await _unitOfWork.MemberRepository.Add(member);
        await _unitOfWork.Complete();
        var memberCreatedViewModel = new MemberCreatedViewModel(member.Id);
        return Result.Ok(memberCreatedViewModel);
    }
}