using EduSubscription.Core.Payments;
using EduSubscription.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduSubscription.Infrastructure.Persistence.Repositories;

public class PaymentRepository : IPaymentRepository
{
    private readonly AppDbContext _appDbContext;

    public PaymentRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task Add(Payment plan)
    {
        await _appDbContext.Payments.AddAsync(plan);
    }

    public async Task<List<Payment>> ReadAll()
    {
        return await _appDbContext.Payments.ToListAsync();
    }
}