using EduSubscription.Application.Providers.Dtos;
using EduSubscription.Application.Providers.Models;
using EduSubscription.Application.Providers.Models.Customers;
using EduSubscription.Application.Providers.Models.Payments;

namespace EduSubscription.Application.Providers;

public interface IPaymentProvider
{
    public Task<bool> AnyCustomerByDocumentNumber(string documentNumber);
    public Task<DefaultResponse<CustomerResponse>> GetCustomerByDocumentNumber(string documentNumber);
    public Task<DefaultResponse<CustomerResponse>> CreateCustomer(CustomerRequest request);
    public Task<DefaultResponse<PaymentResponse>> CreateUniquePaymentSlip(UniquePaymentSlipRequest request);
}