namespace EduSubscription.Application.Providers.Models.Payments;

public record UniquePaymentSlipRequest(string CustomerDocumentNumber, string DueDate, double Value);