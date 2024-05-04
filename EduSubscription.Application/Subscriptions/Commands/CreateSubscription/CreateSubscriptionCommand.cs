using EduSubscription.Application.Subscriptions.Views;
using EduSubscription.Primitives;
using MediatR;

namespace EduSubscription.Application.Subscriptions.Commands.CreateSubscription;

public class CreateSubscriptionCommand : IRequest<Result<SubscriptionCreatedViewModel>>
{
    public CreateSubscriptionCommand(Guid idPlan, Guid idMember)
    {
        IdPlan = idPlan;
        IdMember = idMember;
    }
    public Guid IdPlan { get; set; }
    public Guid IdMember { get; set; }
}