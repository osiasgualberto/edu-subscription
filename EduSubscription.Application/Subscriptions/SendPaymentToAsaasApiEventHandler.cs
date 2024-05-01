using EduSubscription.Application.Providers.Payment;
using EduSubscription.Core.Subscriptions.Events;
using EduSubscription.Primitives.Contracts;
using EduSubscription.Repositories;

namespace EduSubscription.Application.Subscriptions;

public class SendPaymentToAsaasApiEventHandler : IDomainEventHandler<SubscriptionCreatedEvent>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPaymentProvider _paymentProvider;

    public SendPaymentToAsaasApiEventHandler(IPaymentProvider paymentProvider, IUnitOfWork unitOfWork)
    {
        _paymentProvider = paymentProvider;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(SubscriptionCreatedEvent notification, CancellationToken cancellationToken)
    {
        // var paymentRequest = new CreateUniquePaymentRequest("24971563792", DateTime.Now.ToString("dd/MM/yyyy"), notification.Value);
        await _paymentProvider.CreateUniquePaymentSlip(default!);
    }
}