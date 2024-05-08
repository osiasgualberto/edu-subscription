using System.Text.Json.Serialization;
using EduSubscription.Infrastructure.Providers.Asaas.Serialization.Abstractions;
using Newtonsoft.Json;

namespace EduSubscription.Infrastructure.Providers.Asaas.Serialization.Dtos.Payments;

public record PostPaymentsRequestDto : PaymentDto
{
    public PostPaymentsRequestDto(string customer, string billingType, decimal value, DateTime dueDate)
    {
        Customer = customer;
        BillingType = billingType;
        Value = value;
        DueDate = dueDate;
    }
    [JsonProperty("customer")]
    public string Customer { get; set; }
    [JsonProperty("billingType")]
    public string BillingType { get; set; }
    [JsonProperty("value")]
    public decimal Value { get; set; }
    [JsonProperty("dueDate")] public DateTime DueDate { get; set; } 
}