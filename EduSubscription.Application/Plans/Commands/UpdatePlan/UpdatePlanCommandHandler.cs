using EduSubscription.Application.Plans.Views;
using EduSubscription.Core.Plans.Errors;
using EduSubscription.Primitives;
using EduSubscription.Repositories;
using MediatR;

namespace EduSubscription.Application.Plans.Commands.UpdatePlan;

public class UpdatePlanCommandHandler : IRequestHandler<UpdatePlanCommand, Result<PlanUpdatedViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdatePlanCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PlanUpdatedViewModel>> Handle(UpdatePlanCommand request, CancellationToken cancellationToken)
    {
        var plan = await _unitOfWork.PlanRepository.ReadById(request.Id);
        if (plan is null) return Result.Fail<PlanUpdatedViewModel>(PlanErrors.Plan.PlanNotFound);
        plan.Update(request.Description, request.Installments);
        await _unitOfWork.Complete();
        var planUpdatedViewModel = new PlanUpdatedViewModel(plan.Id);
        return Result.Ok(planUpdatedViewModel);
    }
}