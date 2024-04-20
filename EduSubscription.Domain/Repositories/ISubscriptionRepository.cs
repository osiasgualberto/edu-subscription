using EduSubscription.Core.Payments;
using EduSubscription.Core.Plans;
using EduSubscription.Core.Subscriptions;
using EduSubscription.Repositories.Contracts;

namespace EduSubscription.Repositories;

public interface ISubscriptionRepository : IWritableRepository<Subscription>, IReadableAllRepository<Subscription>
{
    public Task AddPlan(Plan plan);
    public Task AddPayment(Payment payment);
    public Task<Plan?> GetPlanById(Guid id);
    public Task<Payment?> GetPayment(Guid id);
}