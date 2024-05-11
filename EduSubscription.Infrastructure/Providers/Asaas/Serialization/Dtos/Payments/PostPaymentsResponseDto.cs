using EduSubscription.Infrastructure.Providers.Asaas.Serialization.Abstractions;
using Newtonsoft.Json;

namespace EduSubscription.Infrastructure.Providers.Asaas.Serialization.Dtos.Payments;

public record PostPaymentsResponseDto : PaymentDto
{
    [JsonProperty("id")] 
    public string Id { get; set; } = string.Empty;
    [JsonProperty("bankSlipUrl")]
    public string Link { get; set; } = string.Empty;
}