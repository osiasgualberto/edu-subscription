﻿using EduSubscription.Application.Members.Views;
using EduSubscription.Repositories;
using MediatR;

namespace EduSubscription.Application.Members.Queries.GetAllMembers;

public class GetAllMembersQueryHandler : IRequestHandler<GetAllMembersQuery, List<MemberViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllMembersQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<MemberViewModel>> Handle(GetAllMembersQuery request, CancellationToken cancellationToken)
    {
        var members = await _unitOfWork.MemberRepository.ReadAll();
        return members
            .Select(o => new MemberViewModel(o.Id, o.FirstName, o.LastName, o.DocumentNumber))
            .ToList();
    }
}