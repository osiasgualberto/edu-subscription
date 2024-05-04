using EduSubscription.Application.Providers.Payment.Models.Requests;
using EduSubscription.Application.Providers.Payment.Models.Responses;

namespace EduSubscription.Application.Providers.Payment;

public interface IPaymentProvider
{
    public Task<CreatedPaymentResponse?> CreatePaymentSlip(CreatePaymentRequest request);
}