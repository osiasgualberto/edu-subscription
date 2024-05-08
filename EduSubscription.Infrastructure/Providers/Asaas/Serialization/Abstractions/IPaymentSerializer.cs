using EduSubscription.Infrastructure.Providers.Asaas.Serialization.Dtos;

namespace EduSubscription.Infrastructure.Providers.Asaas.Serialization.Abstractions;

public interface IPaymentSerializer
{
    public string Serialize<TPaymentDto>(TPaymentDto toBeSerialized) where TPaymentDto : PaymentDto;
    public TPaymentDto? Deserialize<TPaymentDto>(string toBeDeserialized) where TPaymentDto : PaymentDto;
}