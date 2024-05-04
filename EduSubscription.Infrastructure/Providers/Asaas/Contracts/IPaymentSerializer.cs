using EduSubscription.Application.Providers.Payment.Models;

namespace EduSubscription.Infrastructure.Providers.Asaas.Contracts;

public interface IPaymentSerializer
{
    public string Serialize<TPaymentModel>(TPaymentModel toBeSerialized) where TPaymentModel : PaymentModel;
    public TPaymentModel? Deserialize<TPaymentModel>(string toBeDeserialized) where TPaymentModel : PaymentModel;
}