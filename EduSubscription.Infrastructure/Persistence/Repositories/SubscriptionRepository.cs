using EduSubscription.Repositories;
using EduSubscription.Subscriptions;
using Microsoft.EntityFrameworkCore;

namespace EduSubscription.Infrastructure.Persistence.Repositories;

public class SubscriptionRepository : ISubscriptionRepository
{
    private readonly AppDbContext _appDbContext;

    public SubscriptionRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task Add(Subscription entity)
    {
        await _appDbContext.Subscriptions.AddAsync(entity);
    }

    public Task<List<Subscription>> ReadAll()
    {
        return _appDbContext.Subscriptions.ToListAsync();
    }

    public async Task AddPlan(Plan? plan)
    {
        await _appDbContext.Plans.AddAsync(plan);
    }

    public async Task AddPayment(Payment payment)
    {
        await _appDbContext.Payments.AddAsync(payment);
    }

    public async Task<Plan?> GetPlanById(Guid id)
    {
        return await _appDbContext.Plans.SingleOrDefaultAsync(o => o.Id == id);
    }

    public async Task<Payment?> GetPayment(Guid id)
    {
        return await _appDbContext.Payments.SingleOrDefaultAsync(o => o.Id == id);
    }
}