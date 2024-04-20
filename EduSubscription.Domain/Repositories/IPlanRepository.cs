using EduSubscription.Core.Plans;
using EduSubscription.Repositories.Contracts;

namespace EduSubscription.Repositories;

public interface IPlanRepository : IWritableRepository<Plan>, IReadableRepository<Plan>, IReadableAllRepository<Plan>;