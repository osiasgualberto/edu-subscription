using EduSubscription.Application.Plans.Views;
using EduSubscription.Core.Plans;
using EduSubscription.Primitives;
using EduSubscription.Repositories;
using MediatR;

namespace EduSubscription.Application.Plans.Commands.CreatePlan;

public class CreatePlanCommandHandler : IRequestHandler<CreatePlanCommand, Result<PlanCreatedViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePlanCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PlanCreatedViewModel>> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
    {
        var plan = new Plan(request.Description, request.Installments);
        await _unitOfWork.PlanRepository.Add(plan);
        await _unitOfWork.Complete();
        return Result.Ok(new PlanCreatedViewModel(plan.Id));
    }
}