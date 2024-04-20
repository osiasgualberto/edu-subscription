using EduSubscription.Repositories.Contracts;
using EduSubscription.Subscriptions;

namespace EduSubscription.Repositories;

public interface ISubscriptionRepository : IWritableRepository<Subscription>, IReadableAllRepository<Subscription>
{
    public Task AddPlan(Plan plan);
    public Task AddPayment(Payment payment);
    public Task<Plan?> GetPlanById(Guid id);
    public Task<Payment?> GetPayment(Guid id);
}