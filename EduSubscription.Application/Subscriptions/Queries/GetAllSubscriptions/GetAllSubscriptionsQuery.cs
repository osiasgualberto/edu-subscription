using EduSubscription.Application.Plans.Views;
using EduSubscription.Application.Subscriptions.Views;
using EduSubscription.Core.Subscriptions;
using MediatR;

namespace EduSubscription.Application.Subscriptions.Queries.GetAllSubscriptions;

public class GetAllSubscriptionsQuery : IRequest<List<SubscriptionViewModel>>;