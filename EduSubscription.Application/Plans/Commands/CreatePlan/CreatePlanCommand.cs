using EduSubscription.Application.Plans.Views;
using EduSubscription.Primitives;
using MediatR;

namespace EduSubscription.Application.Plans.Commands.CreatePlan;

public class CreatePlanCommand : IRequest<Result<PlanCreatedViewModel>>
{
    public CreatePlanCommand(string description, int durationInMonths)
    {
        Description = description;
        DurationInMonths = durationInMonths;
    }
    public string Description { get; set; }
    public int DurationInMonths { get; set; }
}