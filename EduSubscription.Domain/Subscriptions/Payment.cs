using EduSubscription.Primitives;
using EduSubscription.Subscriptions.Enumerations;

namespace EduSubscription.Subscriptions;

public class Payment : Entity
{
    public Payment(decimal value, string link, EPaymentStatus status, DateTime dueDate, DateTime? processedDate)
    {
        Value = value;
        Link = link;
        Status = status;
        DueDate = dueDate;
        ProcessedDate = processedDate;
    }
    public decimal Value { get; private set; }
    public string Link { get; private set; }
    public EPaymentStatus Status { get; private set; }
    public DateTime DueDate { get; private set; }
    public DateTime? ProcessedDate { get; private set; }
}