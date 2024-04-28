namespace EduSubscription.Infrastructure.Providers.Contracts;

public interface IPaymentClient
{
    public Task<HttpResponseMessage> GetPaymentEndpoint();
    public Task<HttpResponseMessage> PostPaymentEndpoint(string content);
}