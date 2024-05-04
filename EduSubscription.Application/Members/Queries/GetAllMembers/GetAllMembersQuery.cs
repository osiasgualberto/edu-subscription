using EduSubscription.Application.Members.Views;
using MediatR;

namespace EduSubscription.Application.Members.Queries.GetAllMembers;

public record GetAllMembersQuery : IRequest<List<MemberViewModel>>;