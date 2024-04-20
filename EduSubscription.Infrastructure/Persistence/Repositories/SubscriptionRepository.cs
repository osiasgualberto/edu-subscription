using EduSubscription.Core.Payments;
using EduSubscription.Core.Plans;
using EduSubscription.Core.Subscriptions;
using EduSubscription.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduSubscription.Infrastructure.Persistence.Repositories;

public class SubscriptionRepository : ISubscriptionRepository
{
    private readonly AppDbContext _appDbContext;

    public SubscriptionRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task Add(Subscription plan)
    {
        await _appDbContext.Subscriptions.AddAsync(plan);
    }

    public Task<List<Subscription>> ReadAll()
    {
        return _appDbContext.Subscriptions.ToListAsync();
    }

    public Task<Subscription?> ReadById(Guid id)
    {
        return _appDbContext.Subscriptions.SingleOrDefaultAsync(o => o.Id == id);
    }
}