namespace EduSubscription.Infrastructure.Providers.Asaas.Contracts;

public interface IPaymentHttpClient
{
    public Task<HttpResponseMessage> Post(string resource, string content);
    public Task<HttpResponseMessage> Get(string resource);
    public Task<HttpResponseMessage> Get(string resource, Dictionary<string, string> queryParams);
}