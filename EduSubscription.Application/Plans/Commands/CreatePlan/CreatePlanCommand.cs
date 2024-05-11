using EduSubscription.Application.Plans.Views;
using EduSubscription.Primitives;
using MediatR;

namespace EduSubscription.Application.Plans.Commands.CreatePlan;

public class CreatePlanCommand : IRequest<Result<PlanCreatedViewModel>>{

    public CreatePlanCommand(string description, int installments)
    {
        Description = description;
        Installments = installments;
    }
    public string Description { get; set; }
    public int Installments { get; set; }
}