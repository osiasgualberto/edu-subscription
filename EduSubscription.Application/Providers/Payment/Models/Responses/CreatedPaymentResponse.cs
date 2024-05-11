namespace EduSubscription.Application.Providers.Payment.Models.Responses;

public record CreatedPaymentResponse
{
    public CreatedPaymentResponse(string id, string link)
    {
        Id = id;
        Link = link;
    }
    public string Id { get; set; }
    public string Link { get; set; }
}