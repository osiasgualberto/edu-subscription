using EduSubscription.Core.Members.Errors;
using EduSubscription.Primitives;
using EduSubscription.Repositories;
using MediatR;

namespace EduSubscription.Application.Members.Commands.DeleteMember;

public class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteMemberCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.MemberRepository.Delete(request.Id);
        await _unitOfWork.Complete();
        if (!result) return Result.Fail(MemberErrors.Member.MemberNotFound);
        return Result.Ok(result);
    }
}