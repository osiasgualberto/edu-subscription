using EduSubscription.Application.Plans.Views;
using EduSubscription.Primitives;
using MediatR;

namespace EduSubscription.Application.Plans.Commands.UpdatePlan;

public class UpdatePlanCommand : IRequest<Result<PlanUpdatedViewModel>>
{
    public UpdatePlanCommand(Guid id, string description, int installments)
    {
        Id = id;
        Description = description;
        Installments = installments;
    }
    public Guid Id { get; set; }
    public string Description { get; set; }
    public int Installments { get; set; }
}