using EduSubscription.Application.Subscriptions.Views;
using EduSubscription.Primitives;
using MediatR;

namespace EduSubscription.Application.Subscriptions.Commands.CreatePlan;

public class CreatePlanCommand : IRequest<Result<SubscriptionPlanCreatedViewModel>>
{
    public CreatePlanCommand(string description, int durationInMonths)
    {
        Description = description;
        DurationInMonths = durationInMonths;
    }
    public string Description { get; set; }
    public int DurationInMonths { get; set; }
}