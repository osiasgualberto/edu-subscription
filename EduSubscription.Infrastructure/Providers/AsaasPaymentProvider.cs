using System.Text.Json;
using Azure;
using EduSubscription.Application.Providers;
using EduSubscription.Application.Providers.Dtos;
using EduSubscription.Application.Services.Dtos;
using EduSubscription.Infrastructure.Providers.Contracts;

namespace EduSubscription.Infrastructure.Providers;

public class AsaasPaymentProvider : IPaymentProvider
{
    private readonly IPaymentClient _client;

    public AsaasPaymentProvider(IPaymentClient client)
    {
        _client = client;
    }

    public async Task<PaymentResponse?> Execute(PaymentRequest request)
    {
        var resultStream = new MemoryStream();
        await JsonSerializer.SerializeAsync(resultStream, request, new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        if (resultStream.Length == 0) return default!;
        await _client.PostPaymentEndpoint(resultStream.ToString() ?? "");
        return new PaymentResponse();
    }
}