using EduSubscription.Application.Plans.Views;
using EduSubscription.Core.Plans;
using EduSubscription.Core.Plans.Errors;
using EduSubscription.Primitives;
using EduSubscription.Repositories;
using MediatR;

namespace EduSubscription.Application.Plans.Queries.GetByPlanById;

public class GetPlanByIdQueryHandler : IRequestHandler<GetPlanByIdQuery, Result<PlanViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPlanByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<PlanViewModel>> Handle(GetPlanByIdQuery request, CancellationToken cancellationToken)
    {
        var plan = await _unitOfWork.PlanRepository.ReadById(request.Id);
        if (plan is null) return Result.Fail<PlanViewModel>(PlanErrors.Plan.PlanNotFound);
        var planViewModel = new PlanViewModel(plan.Id, plan.Description, plan.DurationInMonths);
        return Result.Ok(planViewModel);
    }
}