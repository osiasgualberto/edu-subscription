namespace EduSubscription.Application.Providers.Payment.Models.Responses;

public record GetCustomerByDocumentNumberResponse
{
    public GetCustomerByDocumentNumberResponse(string externalId, string firstName, string documentNumber, string address)
    {
        ExternalId = externalId;
        FirstName = firstName;
        DocumentNumber = documentNumber;
        Address = address;
    }
    public string ExternalId { get; set; }
    public string FirstName { get; set; } 
    public string DocumentNumber { get; set; } 
    public string Address { get; set; } 
}