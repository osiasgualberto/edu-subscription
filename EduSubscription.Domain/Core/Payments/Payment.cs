using EduSubscription.Core.Payments.Enumerations;
using EduSubscription.Core.Subscriptions;
using EduSubscription.Primitives;

namespace EduSubscription.Core.Payments;

public class Payment : Entity
{
    private Payment(Guid idSubscription, decimal value, string link, EPaymentStatus paymentStatus, DateTime dueDate, DateTime? lastProcessedDate)
    {
        IdSubscription = idSubscription;
        Value = value;
        Link = link;
        PaymentStatus = paymentStatus;
        DueDate = dueDate;
        LastProcessedDate = lastProcessedDate;
    }
    public Guid IdSubscription { get; private set; }
    public Subscription Subscription { get; set; } = null!;
    public decimal Value { get; private set; }
    public string Link { get; private set; }
    public EPaymentStatus PaymentStatus { get; private set; }
    public DateTime DueDate { get; private set; }
    public DateTime? LastProcessedDate { get; private set; }

    public static Payment Create(Guid idSubscription, decimal value, DateTime due)
    {
        var payment = new Payment(idSubscription, value, "", EPaymentStatus.Pending, due, default!);
        return payment;
    }
    
    /// <summary>
    /// Set the payment in failed state.
    /// </summary>
    public void Pending(string externalLink)
    {
        Link = externalLink;
        LastProcessedDate = DateTime.Now;
        PaymentStatus = EPaymentStatus.Pending;
    }

    /// <summary>
    /// Set the payment in failed state.
    /// </summary>
    public void Failed()
    {
        Link = "";
        LastProcessedDate = DateTime.Now;
        PaymentStatus = EPaymentStatus.Failed;
    }
    
}