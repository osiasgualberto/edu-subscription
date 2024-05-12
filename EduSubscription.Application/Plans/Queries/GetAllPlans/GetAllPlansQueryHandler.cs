using EduSubscription.Application.Plans.Views;
using EduSubscription.Application.Subscriptions.Queries.GetAllSubscriptions;
using EduSubscription.Application.Subscriptions.Views;
using EduSubscription.Repositories;
using MediatR;

namespace EduSubscription.Application.Plans.Queries.GetAllPlans;

public class GetAllPlansQueryHandler : IRequestHandler<GetAllPlansQuery, List<PlanViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPlansQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<PlanViewModel>> Handle(GetAllPlansQuery request, CancellationToken cancellationToken)
    {
        var plans = await _unitOfWork.PlanRepository
            .ReadAll();
        var view = plans
            .Select(o => new PlanViewModel(o.Id, o.Description, o.MonthDuration))
            .ToList();
        return view;
    }
}