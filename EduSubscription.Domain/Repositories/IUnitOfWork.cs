namespace EduSubscription.Repositories;

/// <summary>
/// Represents the unit of work pattern.
/// </summary>
public interface IUnitOfWork
{
    public ISubscriptionRepository SubscriptionRepository { get; set; }
    /// <summary>
    /// Completes a transaction.
    /// </summary>
    /// <returns></returns>
    public Task<int> Complete();
}