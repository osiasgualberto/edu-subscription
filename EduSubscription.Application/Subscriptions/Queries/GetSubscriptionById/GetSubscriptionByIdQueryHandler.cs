using EduSubscription.Application.Subscriptions.Views;
using EduSubscription.Core.Subscriptions.Errors;
using EduSubscription.Primitives;
using EduSubscription.Repositories;
using MediatR;

namespace EduSubscription.Application.Subscriptions.Queries.GetSubscriptionById;

public class GetSubscriptionByIdQueryHandler : IRequestHandler<GetSubscriptionByIdQuery, Result<SubscriptionViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetSubscriptionByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SubscriptionViewModel>> Handle(GetSubscriptionByIdQuery request, CancellationToken cancellationToken)
    {
        var subscription = await _unitOfWork.SubscriptionRepository.ReadById(request.Id);
        if (subscription is null) return Result.Fail<SubscriptionViewModel>(SubscriptionsErrors.Subscription.SubscriptionNotFound);
        var subscriptionViewModel = new SubscriptionViewModel(subscription.Id, subscription.IdPlan, subscription.IdMember, subscription.Status,
            subscription.Start, subscription.End);
        return Result.Ok(subscriptionViewModel);
    }
}