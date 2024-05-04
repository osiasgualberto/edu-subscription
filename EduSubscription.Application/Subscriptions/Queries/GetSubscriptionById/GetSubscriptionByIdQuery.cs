using EduSubscription.Application.Subscriptions.Views;
using EduSubscription.Primitives;
using MediatR;

namespace EduSubscription.Application.Subscriptions.Queries.GetSubscriptionById;

public class GetSubscriptionByIdQuery : IRequest<Result<SubscriptionViewModel>>
{
    public GetSubscriptionByIdQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}