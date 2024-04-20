using EduSubscription.Repositories;

namespace EduSubscription.Infrastructure.Persistence;

/// <inheritdoc/>>
public class AppUnitOfWork : IUnitOfWork
{
    public AppUnitOfWork(AppDbContext appDbContext, ISubscriptionRepository subscriptionRepository, IPlanRepository planRepository)
    {
        _appDbContext = appDbContext;
        SubscriptionRepository = subscriptionRepository;
        PlanRepository = planRepository;
    }

    public IPlanRepository PlanRepository { get; set; }
    public ISubscriptionRepository SubscriptionRepository { get; set; }

    private readonly AppDbContext _appDbContext;
    
    /// <inheritdoc/>>
    public async Task<int> Complete()
    {
        return await _appDbContext.SaveChangesAsync();
    }
}