using EduSubscription.Repositories;

namespace EduSubscription.Infrastructure.Persistence;

/// <inheritdoc/>>
public class AppUnitOfWork : IUnitOfWork
{
    public AppUnitOfWork(AppDbContext appDbContext, ISubscriptionRepository subscriptionRepository)
    {
        _appDbContext = appDbContext;
        SubscriptionRepository = subscriptionRepository;

    }
    public ISubscriptionRepository SubscriptionRepository { get; set; }

    private readonly AppDbContext _appDbContext;
    
    /// <inheritdoc/>>
    public async Task<int> Complete()
    {
        return await _appDbContext.SaveChangesAsync();
    }
}