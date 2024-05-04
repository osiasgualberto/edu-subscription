using EduSubscription.Application.Plans.Views;
using EduSubscription.Primitives;
using MediatR;

namespace EduSubscription.Application.Plans.Commands.UpdatePlan;

public class UpdatePlanCommand : IRequest<Result<PlanUpdatedViewModel>>
{
    public UpdatePlanCommand(Guid id, string description, int duration)
    {
        Id = id;
        Description = description;
        Duration = duration;
    }
    public Guid Id { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
}