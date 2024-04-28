using EduSubscription.Application.Providers.Dtos;
using EduSubscription.Application.Services.Dtos;

namespace EduSubscription.Application.Providers;

public interface IPaymentProvider
{
    public Task<PaymentResponse?> Execute(PaymentRequest request);
}