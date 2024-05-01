using System.Net;
using EduSubscription.Application.Providers.Payment;
using EduSubscription.Application.Providers.Payment.Requests;
using EduSubscription.Application.Providers.Payment.Responses;
using EduSubscription.Infrastructure.Providers.Asaas.Clients;
using EduSubscription.Infrastructure.Providers.Asaas.Contracts;
using Newtonsoft.Json;

namespace EduSubscription.Infrastructure.Providers.Asaas;

public class PaymentProvider : IPaymentProvider
{
    private readonly IPaymentHttpClient _httpClient;

    public PaymentProvider(IPaymentHttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<CreatedUniquePaymentResponse?> CreateUniquePaymentSlip(CreatePaymentRequest request)
    {
        var serializedRequest = JsonConvert.SerializeObject(request);
        var httpResponse = await _httpClient.Post(Resources.PaymentEndpoint, serializedRequest);
        if (httpResponse.StatusCode != HttpStatusCode.Created) return default!;
        var strResponse = httpResponse.Content.ReadAsStringAsync().ToString() ?? "";
        var serializedResponse = JsonConvert.DeserializeObject<CreatedUniquePaymentResponse>(strResponse);
        return serializedResponse;
    }
}