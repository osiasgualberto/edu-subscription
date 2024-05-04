using EduSubscription.Application.Providers.Payment;
using EduSubscription.Application.Providers.Payment.Models.Requests;
using EduSubscription.Core.Subscriptions.Events;
using EduSubscription.Primitives.Contracts;
using EduSubscription.Repositories;

namespace EduSubscription.Application.Subscriptions.Events;

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
        var paymentRequest = new CreatePaymentRequest("cus_000005982937", notification.Value, 1, DateTime.Today.AddDays(1), "BOLETO");
        var response = await _paymentProvider.CreatePaymentSlip(paymentRequest);
        if(response is not null) Console.WriteLine(response.Id);
    }
}