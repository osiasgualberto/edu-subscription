using EduSubscription.Core.Plans;
using EduSubscription.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduSubscription.Infrastructure.Persistence.Repositories;

public class PlanRepository : IPlanRepository
{
    private readonly AppDbContext _appDbContext;

    public PlanRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task Add(Plan plan)
    {
        await _appDbContext.Plans.AddAsync(plan);
    }

    public async Task<Plan?> ReadById(Guid id)
    {
        return await _appDbContext.Plans.SingleOrDefaultAsync(o => o.Id == id);
    }

    public async Task<List<Plan>> ReadAll()
    {
        return await _appDbContext.Plans.ToListAsync();
    }
}