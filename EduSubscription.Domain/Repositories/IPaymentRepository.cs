using EduSubscription.Core.Payments;
using EduSubscription.Repositories.Contracts;

namespace EduSubscription.Repositories;

public interface IPaymentRepository : IWritableRepository<Payment>, IReadableAllRepository<Payment>;