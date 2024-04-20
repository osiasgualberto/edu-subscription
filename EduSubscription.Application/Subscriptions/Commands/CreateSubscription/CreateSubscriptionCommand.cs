using EduSubscription.Application.Subscriptions.Views;
using EduSubscription.Primitives;
using MediatR;

namespace EduSubscription.Application.Subscriptions.Commands.CreateSubscription;

public class CreateSubscriptionCommand : IRequest<Result<SubscriptionCreatedViewModel>>
{
    public CreateSubscriptionCommand(Guid idPlan)
    {
        IdPlan = idPlan;
    }
    public Guid IdPlan { get; set; }
}