namespace EduSubscription.Application.Providers.Payment.Models.Requests;

public record CreatePaymentRequest
{
    public CreatePaymentRequest(string customer, decimal value, int installments, DateTime due, string chargeType)
    {
        Customer = customer;
        Value = value;
        Installments = installments;
        Due = due;
        ChargeType = chargeType;
    }
    public string Customer { get; set; } 
    public decimal Value { get; set; }
    public int Installments { get; set; }
    public DateTime Due { get; set; }
    public string ChargeType { get; set; }
}