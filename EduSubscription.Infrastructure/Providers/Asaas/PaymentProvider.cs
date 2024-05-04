using System.Net;
using EduSubscription.Application.Providers.Payment;
using EduSubscription.Application.Providers.Payment.Models.Requests;
using EduSubscription.Application.Providers.Payment.Models.Responses;
using EduSubscription.Infrastructure.Providers.Asaas.Clients;
using EduSubscription.Infrastructure.Providers.Asaas.Contracts;

namespace EduSubscription.Infrastructure.Providers.Asaas;

public class PaymentProvider : IPaymentProvider
{
    private readonly IPaymentHttpClient _httpClient;
    private readonly IPaymentSerializer _serializer;

    public PaymentProvider(IPaymentHttpClient httpClient, IPaymentSerializer serializer)
    {
        _httpClient = httpClient;
        _serializer = serializer;
    }
    
    public async Task<CreatedPaymentResponse?> CreatePaymentSlip(CreatePaymentRequest request)
    {
        var paymentRequest = _serializer.Serialize(request);
        var httpResponse = await _httpClient.Post(Resources.PaymentEndpoint, paymentRequest);
        if (httpResponse.StatusCode != HttpStatusCode.Created) return default!;
        var paymentResponseJson = httpResponse.Content.ReadAsStringAsync().ToString() ?? "";
        var paymentResponse = _serializer.Deserialize<CreatedPaymentResponse>(paymentResponseJson);
        return paymentResponse;
    }
}