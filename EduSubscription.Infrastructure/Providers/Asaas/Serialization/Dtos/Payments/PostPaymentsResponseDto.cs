using EduSubscription.Infrastructure.Providers.Asaas.Serialization.Abstractions;
using Newtonsoft.Json;

namespace EduSubscription.Infrastructure.Providers.Asaas.Serialization.Dtos.Payments;

public record PostPaymentsResponseDto : PaymentDto
{
    public PostPaymentsResponseDto(string id)
    {
        Id = id;
    }
    [JsonProperty("id")]
    public string Id { get; set; }
}