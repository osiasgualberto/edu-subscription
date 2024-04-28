using EduSubscription.Infrastructure.Providers.Contracts;

namespace EduSubscription.Infrastructure.Providers.Clients;

public class AsaasPaymentClient : IPaymentClient
{
    private readonly HttpClient _client;

    public AsaasPaymentClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<HttpResponseMessage> GetPaymentEndpoint()
    {
        var response = await _client.GetAsync(AsaasResource.AsaasPaymentEndpoint);
        return response;
    }

    public async Task<HttpResponseMessage> PostPaymentEndpoint(string content)
    {
        var bodyContent = new StringContent(content);
        var response = await _client.PostAsync(AsaasResource.AsaasPaymentEndpoint, bodyContent);
        return response;
    }
}