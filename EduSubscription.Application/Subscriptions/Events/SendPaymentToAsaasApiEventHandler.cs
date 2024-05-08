using EduSubscription.Application.Providers.Payment;
using EduSubscription.Application.Providers.Payment.Models.Requests;
using EduSubscription.Core.Subscriptions.Events;
using EduSubscription.Primitives.Contracts;
using EduSubscription.Repositories;
using Microsoft.Extensions.Logging;

namespace EduSubscription.Application.Subscriptions.Events;

public class SendPaymentToAsaasApiEventHandler : IDomainEventHandler<SubscriptionCreatedEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPaymentProvider _paymentProvider;
    private readonly ILogger<SendPaymentToAsaasApiEventHandler> _logger;

    public SendPaymentToAsaasApiEventHandler(IPaymentProvider paymentProvider, IUnitOfWork unitOfWork, ILogger<SendPaymentToAsaasApiEventHandler> logger)
    {
        _paymentProvider = paymentProvider;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task Handle(SubscriptionCreatedEvent notification, CancellationToken cancellationToken)
    {
        var member = await _unitOfWork.MemberRepository.ReadById(notification.MemberId);
        if (member is null)
        {
            _logger.LogError("The member {0} was not found during external payment integration.", notification.MemberId.ToString());
            return;
        }
        var customerFromApi = await _paymentProvider.GetCustomerByDocumentNumber(member.DocumentNumber);
        if (customerFromApi is null)
        {
            _logger.LogError("The member with doc. number {0} was not found in the external service.", member.DocumentNumber);
            return;
        }
        var paymentRequest = new CreatePaymentRequest(
            customerFromApi.ExternalId, 
            notification.Value, 
            1, 
            DateTime.Today.AddDays(1), 
            "BOLETO"
        );
        var response = await _paymentProvider.CreatePaymentSlip(paymentRequest);
        if(response is not null) Console.WriteLine(response.Id);
    }
}