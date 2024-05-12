using EduSubscription.Application.Providers.Payment;
using EduSubscription.Application.Providers.Payment.Models.Requests;
using EduSubscription.Core.Payments;
using EduSubscription.Core.Payments.Enumerations;
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
        var member = await _unitOfWork.MemberRepository.ReadById(notification.IdMember);
        if (member is null)
        {
            _logger.LogError("The member {0} was not found during external payment execution.", notification.IdMember.ToString());
            return;
        }
        
        var plan = await _unitOfWork.PlanRepository.ReadById(notification.PlanId);
        if (plan is null)
        {
            _logger.LogError("The plan {0} was not found during external payment execution.", notification.PlanId.ToString());
            return;
        }
        
        var customerFromApi = await _paymentProvider.GetCustomerByDocumentNumber(member.DocumentNumber);
        if (customerFromApi is null)
        {
            _logger.LogError("The member with doc. number {0} was not found in the external service.", member.DocumentNumber);
            return;
        }
        
        var payment = Payment.Create(notification.IdSubscription, 5, DateTime.Now);
        var paymentRequest = new CreatePaymentRequest(
            customerFromApi.ExternalId, 
            payment.Value,
            plan.MonthDuration,
            DateTime.Today.AddDays(1), 
            "BOLETO"
        );
        
        var response = await _paymentProvider.CreatePaymentSlip(paymentRequest);
        
        if (response is null)
        {
            _logger.LogError("Payment provider response is null. Payment id {0} failed.", payment.Id);
            payment.Failed();
            await _unitOfWork.PaymentRepository.Add(payment);
            await _unitOfWork.Complete();
            return;
        }
        
        _logger.LogDebug("Payment provider returned payment id {0}.", payment.Id);
        payment.Pending(response.Link);
        await _unitOfWork.PaymentRepository.Add(payment);
        await _unitOfWork.Complete();
    }
}