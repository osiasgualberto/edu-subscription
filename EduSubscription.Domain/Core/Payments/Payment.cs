using EduSubscription.Core.Payments.Enumerations;
using EduSubscription.Core.Subscriptions;
using EduSubscription.Primitives;

namespace EduSubscription.Core.Payments;

public class Payment : Entity
{
    public Payment(Guid idSubscription, decimal value, string link, EPaymentStatus paymentStatus, DateTime dueDate, DateTime? processedDate)
    {
        IdSubscription = idSubscription;
        Value = value;
        Link = link;
        PaymentStatus = paymentStatus;
        DueDate = dueDate;
        ProcessedDate = processedDate;
    }
    public Guid IdSubscription { get; private set; }
    public Subscription Subscription { get; private set; } = null!;
    public decimal Value { get; private set; }
    public string Link { get; private set; }
    public EPaymentStatus PaymentStatus { get; private set; }
    public DateTime DueDate { get; private set; }
    public DateTime? ProcessedDate { get; private set; }
}