using EduSubscription.Application.Subscriptions.Views;
using EduSubscription.Primitives;
using EduSubscription.Repositories;
using EduSubscription.Subscriptions;
using EduSubscription.Subscriptions.Enumerations;
using EduSubscription.Subscriptions.Errors;
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
        var plan = await _unitOfWork.SubscriptionRepository.GetPlanById(request.IdPlan);
        if (plan is null)
        {
            return Result.Fail<SubscriptionCreatedViewModel>(SubscriptionsErrors.Plan.PlanNotFound);
        }
        var today = DateTime.Now;
        var start = new DateOnly(today.Year, today.Month, today.Day);
        var end = start.AddMonths(plan.DurationInMonths);
        // TODO: verificar como fazer para adicionar o pagamento antes de realizar a criação da assinatura.
        var subscription = new Subscription(ESubscriptionStatus.Pending, start, end, plan.Id);
        await _unitOfWork.SubscriptionRepository.Add(subscription);
        await _unitOfWork.Complete();
        return Result.Ok(new SubscriptionCreatedViewModel(subscription.Id, subscription.IdPlan, EPaymentStatus.Pending));
    }
}