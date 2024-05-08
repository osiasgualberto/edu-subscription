namespace EduSubscription.Application.Providers.Payment.Models.Responses;

public record CreatedPaymentResponse
{
    public CreatedPaymentResponse(string id)
    {
        Id = id;
    }
    public string Id { get; set; }
}