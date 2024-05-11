using System.Net;
using EduSubscription.Application.Providers.Payment;
using EduSubscription.Application.Providers.Payment.Models.Requests;
using EduSubscription.Application.Providers.Payment.Models.Responses;
using EduSubscription.Infrastructure.Providers.Asaas.Clients;
using EduSubscription.Infrastructure.Providers.Asaas.Contracts;
using EduSubscription.Infrastructure.Providers.Asaas.Serialization.Abstractions;
using EduSubscription.Infrastructure.Providers.Asaas.Serialization.Dtos.Customers;
using EduSubscription.Infrastructure.Providers.Asaas.Serialization.Dtos.Payments;
using Microsoft.Extensions.Logging;

namespace EduSubscription.Infrastructure.Providers.Asaas;

public class PaymentProvider : IPaymentProvider
{
    private readonly IPaymentHttpClient _httpClient;
    private readonly IPaymentSerializer _serializer;
    private readonly ILogger<PaymentProvider> _logger;

    public PaymentProvider(IPaymentHttpClient httpClient, IPaymentSerializer serializer, ILogger<PaymentProvider> logger)
    {
        _httpClient = httpClient;
        _serializer = serializer;
        _logger = logger;
    }
    
    public async Task<CreatedPaymentResponse?> CreatePaymentSlip(CreatePaymentRequest request)
    {
        var requestDto = new PostPaymentsRequestDto(request.Customer, "BOLETO", request.Value, request.Due, request.Installments);
        var paymentRequest = _serializer.Serialize(requestDto);
        var httpResponse = await _httpClient.Post(Resources.PaymentEndpoint, paymentRequest);
        if (httpResponse.StatusCode != HttpStatusCode.OK) return default!;
        var paymentResponseJson = await httpResponse.Content.ReadAsStringAsync();
        if (!paymentResponseJson.Any()) return default!;
        var paymentResponse = _serializer.Deserialize<PostPaymentsResponseDto>(paymentResponseJson);
        if (paymentResponse is null) return default!;
        _logger.LogDebug("Payment: {0}", paymentResponse.Id);
        return new CreatedPaymentResponse(paymentResponse.Id, paymentResponse.Link);
    }

    public async Task<GetCustomerByDocumentNumberResponse?> GetCustomerByDocumentNumber(string documentNumber)
    {
        if (!documentNumber.Any()) return default!;
        var httpResponse = await _httpClient.Get(Resources.CustomerEndpoint, new()
        {
            { "cpfCnpj", documentNumber }
        });
        if (httpResponse.StatusCode != HttpStatusCode.OK) return null!;
        var customerResponseJson = await httpResponse.Content.ReadAsStringAsync();
        if (!customerResponseJson.Any()) return default!;
        var customerResponse = _serializer.Deserialize<GetCustomersResponseDto>(customerResponseJson);
        if (customerResponse is null) return default!;
        if (customerResponse.Customers.Count == 0) return default!;
        var foundCustomer = customerResponse.Customers.First();
        _logger.LogDebug("Customer: {0} - {1}", foundCustomer.Id, foundCustomer.Name);
        return new GetCustomerByDocumentNumberResponse(foundCustomer.Id, foundCustomer.Name, "", "");
    }
}