namespace EduSubscription.Repositories;

/// <summary>
/// Represents the unit of work pattern.
/// </summary>
public interface IUnitOfWork
{
    public IPlanRepository PlanRepository { get; set; }
    public ISubscriptionRepository SubscriptionRepository { get; set; }
    public IMemberRepository MemberRepository { get; set; }
    
    /// <summary>
    /// Completes a transaction.
    /// </summary>
    /// <returns></returns>
    public Task<int> Complete();
}