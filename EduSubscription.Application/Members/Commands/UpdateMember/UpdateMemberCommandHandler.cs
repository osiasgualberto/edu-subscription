using EduSubscription.Application.Members.Views;
using EduSubscription.Core.Members.Errors;
using EduSubscription.Primitives;
using EduSubscription.Repositories;
using MediatR;

namespace EduSubscription.Application.Members.Commands.UpdateMember;

public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, Result<MemberUpdatedViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateMemberCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<MemberUpdatedViewModel>> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
    {
        var member = await _unitOfWork.MemberRepository.ReadById(request.Id);
        if (member is null) return Result.Fail<MemberUpdatedViewModel>(MemberErrors.Member.MemberNotFound);
        member.Update(request.FirstName, request.LastName, request.DocumentNumber);
        await _unitOfWork.Complete();
        var memberUpdatedViewModel = new MemberUpdatedViewModel(member.Id);
        return Result.Ok(memberUpdatedViewModel);
    }
}