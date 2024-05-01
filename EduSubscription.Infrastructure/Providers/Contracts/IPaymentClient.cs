using System.Net;

namespace EduSubscription.Infrastructure.Providers.Contracts;

public interface IPaymentClient
{
    public Task<HttpResponseMessage> Post(string resource, string content);
    public Task<HttpResponseMessage> Get(string resource);
    public Task<HttpResponseMessage> Get(string resource, Dictionary<string, string> queryParams);
}