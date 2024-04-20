using EduSubscription.Application.Subscriptions.Views;
using MediatR;

namespace EduSubscription.Application.Subscriptions.Queries.GetAllSubscriptions;

public class GetAllSubscriptionsQuery : IRequest<List<SubscriptionViewModel>>;