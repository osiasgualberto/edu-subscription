using EduSubscription.Application.Plans.Views;
using MediatR;

namespace EduSubscription.Application.Plans.Queries.GetAllPlans;

public class GetAllPlansQuery : IRequest<List<PlanViewModel>>;