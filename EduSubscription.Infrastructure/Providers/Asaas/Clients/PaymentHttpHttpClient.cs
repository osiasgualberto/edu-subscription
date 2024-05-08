using EduSubscription.Infrastructure.Providers.Asaas.Contracts;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace EduSubscription.Infrastructure.Providers.Asaas.Clients;

public class PaymentHttpHttpClient : IPaymentHttpClient
{
    private readonly HttpClient _client;
    private readonly ILogger<PaymentHttpHttpClient> _logger;

    public PaymentHttpHttpClient(HttpClient client, ILogger<PaymentHttpHttpClient> logger)
    {
        _client = client;
        _logger = logger;
    }

    public async Task<HttpResponseMessage> Get(string resource)
    {
        var response = await _client.GetAsync(resource);
        var stringResponse = await response.Content.ReadAsStringAsync();
        _logger.LogDebug(stringResponse);
        return response;
    }

    public async Task<HttpResponseMessage> Get(string resource, Dictionary<string, string> queryParams)
    {
        var requestUri = QueryHelpers.AddQueryString(resource, queryParams!);
        var response = await _client.GetAsync(requestUri);
        var stringResponse = await response.Content.ReadAsStringAsync();
        _logger.LogDebug(stringResponse);
        return response;
    }

    public async Task<HttpResponseMessage> Post(string resource, string content)
    {
        var bodyContent = new StringContent(content);
        var response = await _client.PostAsync(resource, bodyContent);
        var stringResponse = await response.Content.ReadAsStringAsync();
        _logger.LogDebug(stringResponse);
        return response;
    }
}