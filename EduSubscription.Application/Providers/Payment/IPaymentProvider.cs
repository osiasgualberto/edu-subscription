using EduSubscription.Application.Providers.Payment.Requests;
using EduSubscription.Application.Providers.Payment.Responses;

namespace EduSubscription.Application.Providers.Payment;

public interface IPaymentProvider
{
    public Task<CreatedUniquePaymentResponse?> CreateUniquePaymentSlip(CreatePaymentRequest request);
}