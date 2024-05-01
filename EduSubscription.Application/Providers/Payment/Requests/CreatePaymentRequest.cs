namespace EduSubscription.Application.Providers.Payment.Requests;

public class CreatePaymentRequest
{
    public string CustomerDocument { get; set; } = string.Empty;
    public decimal Value { get; set; } = 0M;
    public int Installments { get; set; } = 1;
    public DateTime Due { get; set; }
};