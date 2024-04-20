using EduSubscription.Application.Subscriptions.Views;
using EduSubscription.Repositories;
using MediatR;

namespace EduSubscription.Application.Subscriptions.Queries.GetAllSubscriptions;

public class GetAllSubscriptionsQueryHandler : IRequestHandler<GetAllSubscriptionsQuery, List<SubscriptionViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllSubscriptionsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<SubscriptionViewModel>> Handle(GetAllSubscriptionsQuery request, CancellationToken cancellationToken)
    {
        var subscriptions = await _unitOfWork.SubscriptionRepository
            .ReadAll();
        var view = subscriptions
            .Select(o => new SubscriptionViewModel(o.IdPlan, o.IdPayment, o.Status, o.Start, o.End))
            .ToList();
        return view;
    }
}