using EduSubscription.Application.Subscriptions.Views;
using EduSubscription.Primitives;
using EduSubscription.Repositories;
using EduSubscription.Subscriptions;
using MediatR;

namespace EduSubscription.Application.Subscriptions.Commands.CreatePlan;

public class CreatePlanCommandHandler : IRequestHandler<CreatePlanCommand, Result<SubscriptionPlanCreatedViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePlanCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<SubscriptionPlanCreatedViewModel>> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
    {
        var plan = new Plan(request.Description, request.DurationInMonths);
        await _unitOfWork.SubscriptionRepository.AddPlan(plan);
        await _unitOfWork.Complete();
        return Result.Ok(new SubscriptionPlanCreatedViewModel(plan.Id));
    }
}