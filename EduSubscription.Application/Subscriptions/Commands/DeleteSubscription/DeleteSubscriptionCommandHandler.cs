using EduSubscription.Application.Subscriptions.Commands.CreateSubscription;
using EduSubscription.Application.Subscriptions.Views;
using EduSubscription.Core.Members.Errors;
using EduSubscription.Core.Plans.Errors;
using EduSubscription.Core.Subscriptions;
using EduSubscription.Core.Subscriptions.Errors;
using EduSubscription.Primitives;
using EduSubscription.Repositories;
using MediatR;

namespace EduSubscription.Application.Subscriptions.Commands.DeleteSubscription;

public class DeleteSubscriptionCommandHandler : IRequestHandler<DeleteSubscriptionCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteSubscriptionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.SubscriptionRepository.Delete(request.Id);
        await _unitOfWork.Complete();
        if (!result) return Result.Fail<SubscriptionDeletedViewModel>(SubscriptionsErrors.Subscription.SubscriptionNotFound);
        return Result.Ok(result);
    }
}