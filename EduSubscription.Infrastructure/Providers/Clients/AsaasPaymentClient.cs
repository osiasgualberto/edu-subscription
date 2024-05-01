using System.Net;
using EduSubscription.Infrastructure.Providers.Contracts;
using Microsoft.AspNetCore.WebUtilities;

namespace EduSubscription.Infrastructure.Providers.Clients;

public class AsaasPaymentClient : IPaymentClient
{
    private readonly HttpClient _client;

    public AsaasPaymentClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<HttpResponseMessage> Get(string resource)
    {
        var response = await _client.GetAsync(resource);
        return response;
    }

    public async Task<HttpResponseMessage> Get(string resource, Dictionary<string, string> queryParams)
    {
        var requestUri = QueryHelpers.AddQueryString(resource, queryParams!);
        var response = await _client.GetAsync(requestUri);
        return response;
    }

    public async Task<HttpResponseMessage> Post(string resource, string content)
    {
        var bodyContent = new StringContent(content);
        var response = await _client.PostAsync(resource, bodyContent);
        return response;
    }
}