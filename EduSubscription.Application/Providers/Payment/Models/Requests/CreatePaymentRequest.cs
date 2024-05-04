namespace EduSubscription.Application.Providers.Payment.Models.Requests;

public record CreatePaymentRequest(string Customer, double Value, int Installments, DateTime Due, string ChargeType) : PaymentModel;