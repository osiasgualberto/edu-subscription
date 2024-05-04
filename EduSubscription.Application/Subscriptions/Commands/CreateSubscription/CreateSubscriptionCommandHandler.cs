using EduSubscription.Application.Subscriptions.Views;
using EduSubscription.Core.Members.Errors;
using EduSubscription.Core.Plans.Errors;
using EduSubscription.Core.Subscriptions;
using EduSubscription.Core.Subscriptions.Errors;
using EduSubscription.Primitives;
using EduSubscription.Repositories;
using MediatR;

namespace EduSubscription.Application.Subscriptions.Commands.CreateSubscription;

public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, Result<SubscriptionCreatedViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateSubscriptionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SubscriptionCreatedViewModel>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var plan = await _unitOfWork.PlanRepository.ReadById(request.IdPlan);
        if (plan is null)
        {
            return Result.Fail<SubscriptionCreatedViewModel>(PlanErrors.Plan.PlanNotFound);
        }
        var member = await _unitOfWork.MemberRepository.ReadById(request.IdMember);
        if (member is null)
        {
            return Result.Fail<SubscriptionCreatedViewModel>(MemberErrors.Member.MemberNotFound);
        }
        var subscription = Subscription.Create(plan.Id, member.Id);
        await _unitOfWork.SubscriptionRepository.Add(subscription);
        await _unitOfWork.Complete();
        return Result.Ok(new SubscriptionCreatedViewModel(subscription.Id));
    }
}