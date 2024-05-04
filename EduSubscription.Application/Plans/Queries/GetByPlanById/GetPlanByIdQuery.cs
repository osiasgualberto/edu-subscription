using EduSubscription.Application.Plans.Views;
using EduSubscription.Primitives;
using MediatR;

namespace EduSubscription.Application.Plans.Queries.GetByPlanById;

public class GetPlanByIdQuery : IRequest<Result<PlanViewModel>>
{
    public GetPlanByIdQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }
}