using EduSubscription.Core.Payments;
using EduSubscription.Core.Plans;
using EduSubscription.Core.Subscriptions;
using EduSubscription.Repositories.Contracts;

namespace EduSubscription.Repositories;

public interface ISubscriptionRepository : IWritableRepository<Subscription>, IReadableAllRepository<Subscription>, IReadableRepository<Subscription>;