using EduSubscription.Application.Providers;
using EduSubscription.Application.Services.Dtos;
using EduSubscription.Core.Subscriptions.Events;
using EduSubscription.Primitives.Contracts;

namespace EduSubscription.Application.Subscriptions;

public class SendPaymentToAsaasApiEventHandler : IDomainEventHandler<SubscriptionCreatedEvent>
{
    private readonly IPaymentProvider _paymentProvider;

    public SendPaymentToAsaasApiEventHandler(IPaymentProvider paymentProvider)
    {
        _paymentProvider = paymentProvider;
    }

    public async Task Handle(SubscriptionCreatedEvent notification, CancellationToken cancellationToken)
    {
        await _paymentProvider.Execute(new PaymentRequest());
    }
}