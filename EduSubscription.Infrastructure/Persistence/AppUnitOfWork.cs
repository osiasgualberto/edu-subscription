using EduSubscription.Infrastructure.Persistence.Repositories;
using EduSubscription.Repositories;

namespace EduSubscription.Infrastructure.Persistence;

/// <inheritdoc/>>
public class AppUnitOfWork : IUnitOfWork
{
    public AppUnitOfWork(AppDbContext appDbContext, ISubscriptionRepository subscriptionRepository, IPlanRepository planRepository, IPaymentRepository paymentRepository, IMemberRepository memberRepository, ICourseRepository courseRepository)
    {
        _appDbContext = appDbContext;
        SubscriptionRepository = subscriptionRepository;
        PlanRepository = planRepository;
        PaymentRepository = paymentRepository;
        MemberRepository = memberRepository;
        CourseRepository = courseRepository;
    }

    public IPlanRepository PlanRepository { get; set; }
    public ISubscriptionRepository SubscriptionRepository { get; set; }
    public IPaymentRepository PaymentRepository { get; set; }
    public IMemberRepository MemberRepository { get; set; }
    public ICourseRepository CourseRepository { get; set; }
    
    private readonly AppDbContext _appDbContext;
    
    /// <inheritdoc/>>
    public async Task<int> Complete()
    {
        return await _appDbContext.SaveChangesAsync();
    }
}