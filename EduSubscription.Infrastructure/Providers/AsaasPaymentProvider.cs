using EduSubscription.Application.Providers;
using EduSubscription.Application.Providers.Dtos;
using EduSubscription.Application.Providers.Models;
using EduSubscription.Application.Providers.Models.Customers;
using EduSubscription.Application.Providers.Models.Payments;
using EduSubscription.Infrastructure.Providers.Clients;
using EduSubscription.Infrastructure.Providers.Contracts;
using Newtonsoft.Json;

namespace EduSubscription.Infrastructure.Providers;

public class AsaasPaymentProvider : IPaymentProvider
{
    private readonly IPaymentClient _client;

    public AsaasPaymentProvider(IPaymentClient client)
    {
        _client = client;
    }

    public async Task<bool> AnyCustomerByDocumentNumber(string documentNumber)
    {
        var response = await GetCustomerByDocumentNumber(documentNumber);
        if (response.Count == 0) return false;
        return true;
    }

    public async Task<DefaultResponse<CustomerResponse>> GetCustomerByDocumentNumber(string documentNumber)
    {
        var customer = await _client.Get(AsaasResource.CustomerEndpoint, new()
        {
            {"cpfCnpj", documentNumber}
        });
        return JsonConvert.DeserializeObject<DefaultResponse<CustomerResponse>>(
            await customer.Content.ReadAsStringAsync())!;
    }

    public Task<DefaultResponse<CustomerResponse>> CreateCustomer(CustomerRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<DefaultResponse<PaymentResponse>> CreateUniquePaymentSlip(UniquePaymentSlipRequest request)
    {
        var customer = await GetCustomerByDocumentNumber(request.CustomerDocumentNumber);
    }
}