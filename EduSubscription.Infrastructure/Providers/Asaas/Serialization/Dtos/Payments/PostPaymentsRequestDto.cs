using System.Text.Json.Serialization;
using EduSubscription.Infrastructure.Providers.Asaas.Serialization.Abstractions;
using Newtonsoft.Json;

namespace EduSubscription.Infrastructure.Providers.Asaas.Serialization.Dtos.Payments;

public record PostPaymentsRequestDto : PaymentDto
{
    public PostPaymentsRequestDto(string customer, string billingType, decimal value, DateTime dueDate, int installments)
    {
        Customer = customer;
        BillingType = billingType;
        Value = value;
        DueDate = dueDate;
        Installments = installments;
    }
    [JsonProperty("customer")]
    public string Customer { get; set; }
    [JsonProperty("billingType")]
    public string BillingType { get; set; }
    [JsonProperty("dueDate")] 
    public DateTime DueDate { get; set; } 
    [JsonProperty("installmentCount")] 
    public int Installments { get; set; } 
    [JsonProperty("installmentValue")]
    public decimal Value { get; set; }
}