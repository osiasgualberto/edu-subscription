using EduSubscription.Core.Members;
using EduSubscription.Repositories.Contracts;

namespace EduSubscription.Repositories;

public interface IMemberRepository : IWritableRepository<Member>, IReadableAllRepository<Member>, IDeletableRepository,
    IReadableRepository<Member>;
