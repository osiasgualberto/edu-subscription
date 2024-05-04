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

    public async Task Add(Subscription member)
    {
        await _appDbContext.Subscriptions.AddAsync(member);
    }

    public Task<List<Subscription>> ReadAll()
    {
        return _appDbContext.Subscriptions.ToListAsync();
    }

    public Task<Subscription?> ReadById(Guid id)
    {
        return _appDbContext.Subscriptions.SingleOrDefaultAsync(o => o.Id == id);
    }

    public async Task<bool> Delete(Guid id)
    {
        var subscription = await ReadById(id);
        if (subscription is null) return false;
        _appDbContext.Subscriptions.Remove(subscription);
        return true;
    }
}