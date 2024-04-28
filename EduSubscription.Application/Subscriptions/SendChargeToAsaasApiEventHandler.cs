using EduSubscription.Application.Providers;
using EduSubscription.Application.Services.Dtos;
using EduSubscription.Core.Subscriptions.Events;
using EduSubscription.Primitives.Contracts;
using MediatR;

namespace EduSubscription.Application.Subscriptions;

public class SendChargeToAsaasApiEventHandler : IDomainEventHandler<SubscriptionCreatedEvent>
{
    private readonly IPaymentProvider _paymentProvider;

    public SendChargeToAsaasApiEventHandler(IPaymentProvider paymentProvider)
    {
        _paymentProvider = paymentProvider;
    }

    public async Task Handle(SubscriptionCreatedEvent notification, CancellationToken cancellationToken)
    {
        await _paymentProvider.Execute(new PaymentRequest());
    }
}