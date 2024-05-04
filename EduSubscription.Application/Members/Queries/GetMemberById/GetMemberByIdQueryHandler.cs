using EduSubscription.Application.Members.Views;
using EduSubscription.Core.Members.Errors;
using EduSubscription.Primitives;
using EduSubscription.Repositories;
using MediatR;

namespace EduSubscription.Application.Members.Queries.GetMemberById;

public class GetMemberByIdQueryHandler : IRequestHandler<GetMemberByIdQuery, Result<MemberViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetMemberByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<MemberViewModel>> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
    {
        var member = await _unitOfWork.MemberRepository.ReadById(request.Id);
        if (member is null) return Result.Fail<MemberViewModel>(MemberErrors.Member.MemberNotFound);
        var memberViewModel = new MemberViewModel(member.Id, member.FirstName, member.LastName);
        return Result.Ok(memberViewModel);
    }
}