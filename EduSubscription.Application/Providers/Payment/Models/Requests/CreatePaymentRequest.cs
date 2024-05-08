namespace EduSubscription.Application.Providers.Payment.Models.Requests;

public record CreatePaymentRequest(string Customer, decimal Value, int Installments, DateTime Due, string ChargeType);